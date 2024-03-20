using App.DataAccessLibrary.Infrastructure.IRepository;
using App.DataAccessLibrary.Infrastructure.Repository;
using App.Models;
using App.Models.Models;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        private IUnitofWork _unitofWork;
        private IWebHostEnvironment _webHostEnvironment;

        public HomeController(IUnitofWork unitofWork , IWebHostEnvironment webHostEnvironment) 
        {
            _unitofWork = unitofWork;
            _webHostEnvironment = webHostEnvironment;
        }
        [Route("/")]
        [Route("Home")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Login")]
        public IActionResult LoginUser()
        {
			if (HttpContext.Session.GetString("UserSession") != null)
			{
				return RedirectToAction("Index");

			}
			else
			{
				return View();
			}
		}


		[ValidateAntiForgeryToken]
		[HttpPost]
		[Route("Login")]
		public IActionResult LoginUser(string username, string password)
		{
			// Directly validate the plaintext email and password with the database
			if (_unitofWork.EmpRegisterRepository.ValidateUser(username, password))
			{
				// Set user email in session after successful validation
				HttpContext.Session.SetString("UserEmail", username);

				// Redirect to a secured page
				return RedirectToAction("Index");
			}
			else
			{
				// Display an error message if credentials are invalid
				ViewBag.ErrorMessage = "Invalid credentials";
				return View("LoginUser"); // Make sure the view name is correct
			}
		}

        [HttpPost]
        public IActionResult LogoutUser()
        {
            // Clear the user's session
            HttpContext.Session.Remove("UserEmail");

            // Redirect to the homepage or login page
            return RedirectToAction("Index");
        }



        [Route("Contact")]
		public IActionResult Contact()
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
