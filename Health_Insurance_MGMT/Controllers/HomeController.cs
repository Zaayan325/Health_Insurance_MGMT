using App.DataAccessLibrary.Infrastructure.IRepository;
using App.DataAccessLibrary.Infrastructure.Repository;
using App.Models;
using App.Models.Models;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Http;
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
			if (HttpContext.Session.GetInt32("User_Id") != null)
			{

				return RedirectToAction("Index");

			}
			else
			{
				return View();
			}
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		[Route("Login")]
		public IActionResult LoginUser(string username, string password, int empno)
		{
			// Directly validate the plaintext email and password with the database
			if (_unitofWork.EmpRegisterRepository.ValidateUser(username, password, empno))
			{
				// Set user email in session after successful validation
				HttpContext.Session.SetInt32("User_Id", empno);
                
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
            
            HttpContext.Session.Remove("User_Id");

            // Redirect to the homepage or login page
            return RedirectToAction("Index");
        }

        [Route("UserDashboard")]
        public async Task<IActionResult> UserDashboard(int id)
        {
            if (HttpContext.Session.GetInt32("User_Id") != null)
            {
                var employee = _unitofWork.EmpRegisterRepository.GetT(emp => emp.empno == id);
                if (employee == null)
                {
                    return NotFound();
                }
                // Assuming _unitOfWork.EmpRegisterRepository has a method to asynchronously find an employee by ID including their policies
                // This part will be different based on your actual implementation of the repository
                employee = await _unitofWork.EmpRegisterRepository.FindEmployeeAndPolicyAsync(id); // Replace with actual async method

                return View("UserDashboard", employee);
            }
            else
            {
                return RedirectToAction("LoginUser");
            }
        }


        [Route("Contact")]
		public IActionResult Contact()
        {
            if (HttpContext.Session.GetInt32("User_Id") == null)
            {
                return RedirectToAction("LoginUser");

			}
			else
			{
                return View();

            }
            
        }

		// POST: ContactController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Route("Contact")]
		public IActionResult Contact(Contact contacts)
		{
            
			
			
				if (ModelState.IsValid)
				{
					_unitofWork.ContactRepository.Add(contacts);
					_unitofWork.save();
					TempData["Message_Success"] = "Your Message Has Beeen Send";
					return RedirectToAction("Index");

				}
				else
				{
                    return View(contacts);
                }
            

            
		}



		//For Viewing It 

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
