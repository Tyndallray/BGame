using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGame.Models
{
    public class Cart
    {
        private List<OrderItem> orderCollection = new List<OrderItem>();

        public virtual void AddItem(GameItem pGameItem, int pQuantity)
        {
            OrderItem tOrderItem = orderCollection.Where(p => p.GameItem.GameItemId == pGameItem.GameItemId).FirstOrDefault();

            if (tOrderItem == null)
            {
                orderCollection.Add(new OrderItem { GameItem = pGameItem, Quantity = pQuantity });
            }
            else
            {
                tOrderItem.Quantity += pQuantity;
            }
        }
        public virtual void RemoveOrderItem(GameItem pGameItem) => orderCollection.RemoveAll(l => l.GameItem.GameItemId == pGameItem.GameItemId);

        public virtual float ComputeTotalValue() => orderCollection.Sum(e => e.GameItem.Price * e.Quantity);

        public virtual void Clear() => orderCollection.Clear();
        public virtual IEnumerable<OrderItem> Orders => orderCollection;

    }

    
}
