﻿// using IntexII_0305.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IntexII_0305.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AccountManager()
        {
            return View();
        }

        public IActionResult BurialSummary()
        {
            return View();
        }

        public IActionResult RecordManager()
        {
            return View();
        }

        public IActionResult HeadDirectionPred()
        {
            return View();
        }

        public IActionResult UnsupervisedFindings()
        {
            return View();
        }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        // }


    }
}