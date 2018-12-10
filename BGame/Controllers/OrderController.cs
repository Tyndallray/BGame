using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BGame.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BGame.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private IOrderRepository repository;
        private Cart cart;
        public OrderController(IOrderRepository repoService, Cart cartService)
        {
            repository = repoService;
            cart = cartService;
        }
        
        public ViewResult Checkout() => View(new Order());[HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cart.Orders.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                order.OrderItemList = cart.Orders.ToArray();
                order.date = DateTime.Now;
                repository.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(order);
            }
        }

        public ViewResult Completed()
        {
            cart.Clear(); return View();
        }
        public ViewResult List() => View(repository.Orders.Where(tOrder => !tOrder.isCompleted));

        [HttpPost]
        public IActionResult CompleteOrder(int orderID)
        {
            Order order = repository.Orders.FirstOrDefault(tOrder => tOrder.OrderID == orderID);

            if (order != null)
            {
                order.isCompleted = true;
                repository.SaveOrder(order);
            }

            return RedirectToAction(nameof(List));
        }
    }
}