using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGame.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private BGameDbContext context;
        public EFOrderRepository(BGameDbContext ctx) { context = ctx; }
        public IQueryable<Order> Orders => context.Orders.Include(o => o.OrderItemList).ThenInclude(l => l.GameItem);

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.OrderItemList.Select(l => l.GameItem));
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}