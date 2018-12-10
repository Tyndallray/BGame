using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BGame.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BGame.Controllers
{
    public class CartController : Controller
    {
        private IGameItem repository;
        private Cart cart;
        public CartController(IGameItem repo, Cart cartService)
        {
            repository = repo;
            cart = cartService;
        }
        [Authorize]        
        public ViewResult Index()
        {
            return View(cart);
        }
        [HttpPost]
        public IActionResult AddToCart(int pID)
        {
            GameItem tItem = repository.GameItems.FirstOrDefault(p => p.GameItemId == pID);

            if (tItem != null)
                cart.AddItem(tItem, 1); 

            return RedirectToAction("Index",cart);
        }
        [HttpPost]
        public RedirectToActionResult RemoveFromCart(int pID)
        {
            GameItem tItem = repository.GameItems.FirstOrDefault(p => p.GameItemId == pID);

            if (tItem != null)
                cart.RemoveOrderItem(tItem);

            return RedirectToAction("Index",cart);
        }
    }
}