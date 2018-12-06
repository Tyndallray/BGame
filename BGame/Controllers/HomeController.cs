using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BGame.Models.UserModels;
using Microsoft.AspNetCore.Authorization;

namespace BGame.Controllers
{
    public class HomeController : Controller
    {
      //  private IUserInterface UserRepository;

        public HomeController()
        {
          //  UserRepository = x;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ChatPage()
        {
            return View();
        }

        public IActionResult BuyPage()
        {
            return View();
        }
        [Authorize]
        public IActionResult SellPage()
        {
            return View();
        }

        // !! move to account controller !!

        //public IActionResult Register()
        //{

        //    return View();
        //}
        //public IActionResult Login()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult RegisterAndLogin( User user)
        //{
        //    UserRepository.Add(user);
        //    return View("Index");
        //}

    }
}