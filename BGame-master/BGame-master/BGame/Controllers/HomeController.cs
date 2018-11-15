using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BGame.Models.UserModels;

namespace BGame.Controllers
{
    public class HomeController : Controller
    {
        private IUserInterface UserRepository;

        public HomeController(IUserInterface x)
        {
            UserRepository = x;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BuyPage()
        {
            return View();
        }

        public IActionResult SellPage()
        {
            return View();
        }
        public IActionResult Register()
        {

            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register( User user)
        {
            UserRepository.Add(user);
            return View("Index");
        }

    }
}