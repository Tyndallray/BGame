using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BGame.Models.UserModels;
using Microsoft.AspNetCore.Authorization;
using BGame.Models;

namespace BGame.Controllers
{
    public class HomeController : Controller
    {
     
        public HomeController()
        {
          
        }

        public IActionResult Index()
        {
            return View();
        }

        public ViewResult UserDetails() {
            return View();
        }

        //public IActionResult ChatPage()
        //{
        //    return View();
        //}

        //public IActionResult BuyPage()
        //{
        //    return View();
        //}
        //[Authorize]
        //public IActionResult SellPage()
        //{

        //}

    }
}