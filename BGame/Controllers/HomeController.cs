﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BGame.Controllers
{
    public class HomeController : Controller
    {
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

    }
}