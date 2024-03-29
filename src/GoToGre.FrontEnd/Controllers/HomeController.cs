﻿using GoToGre.FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GoToGre.FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
                public IActionResult Index()
        {
            return View();
        }
        public IActionResult Member()
        {
            return View();
        }
        public IActionResult AddMember()
        {
            return View();
        }
        public IActionResult UpdateMember()
        {
            return View();
        }

        public IActionResult DeleteMember()
        {
            return View();
        }
        public IActionResult Inventory()
        {
            return View();
        }
        public IActionResult AddProduct()
        {
            return View();
        }

        public IActionResult UpdateProduct()
        {
            return View();
        }

        public IActionResult DeleteProduct() {
            return View();
        }


        public IActionResult Privacy()

        {
            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
