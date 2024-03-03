﻿using App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Route("/")]
        [Route("Home")]
        public IActionResult Index()
        {
            return View();
        }
		[Route("Aboutus")]
		public IActionResult About()
        {
            return View();
        }
		[Route("Contact")]
		public IActionResult Contact()
        {
            return View();
        }
		[Route("FeedBack")]
		public IActionResult Feedback()
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
