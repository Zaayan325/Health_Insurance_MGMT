using App.DataAccessLibrary.Infrastructure.IRepository;
using App.DataAccessLibrary.Infrastructure.Repository;
using App.Models;
using App.Models.Models;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

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
            var insuranceCompanies = _unitofWork.InsuranceCompanyRepository.GetAllInsuranceCompanies();
            return View(insuranceCompanies);
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
            if (HttpContext.Session.GetInt32("User_Id") == null)
            {
                return RedirectToAction("LoginUser");

            }
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
        //Login For the Admin 

        [Route("LoginAdmin")]
        public IActionResult LoginAdmin()
        {
            if (HttpContext.Session.GetInt32("Adm_Id") != null)
            {

                return RedirectToAction("Index");

            }
            else
            {
                return View();
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

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Route("LoginAdmin")]
		public IActionResult LoginAdmin(string Email, string AdminPassword, int Adm_ID)
		{
			// Directly validate the plaintext email and password with the database
			if (_unitofWork.AdminLoginRepository.ValidateAdmin(Email, AdminPassword, Adm_ID))
			{
				// Set user email in session after successful validation
				HttpContext.Session.SetInt32("Adm_Id", Adm_ID);
				var adminImageUrl = _unitofWork.AdminLoginRepository.GetAdminImageUrlById(Adm_ID);
                //var admindesignation = _unitofWork.AdminLoginRepository.GetAdminDesignation(Adm_ID);
				HttpContext.Session.SetString("AdminImageUrl", adminImageUrl); // Store image URL in session
				HttpContext.Session.SetString("AdminUsername", Email); // Store username URL in session

                
                

				// Redirect to a secured page
				return RedirectToAction("Index");
			}

			else
			{
				// Display an error message if credentials are invalid
				ViewBag.ErrorMessage = "Invalid credentials";
				return View("LoginAdmin"); // Make sure the view name is correct
			}
		}

        [HttpPost]
        public IActionResult AdminLogout()
        {
            if (HttpContext.Session.GetInt32("Adm_Id") == null)
            {
                return RedirectToAction("LoginAdmin", "Home");

            }
            // Clear the user's session

            HttpContext.Session.Remove("Adm_Id");

            // Redirect to the homepage or login page
            return RedirectToAction("Index");
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

        [HttpGet]
        public IActionResult LockScreen()
        {
            if (HttpContext.Session.GetInt32("Adm_Id") == null)
            {
                return RedirectToAction("LoginAdmin", "Home");

            }
            // Set a flag in session to indicate the session is locked
            HttpContext.Session.SetString("IsLocked", "true");
            ViewBag.AdminUsername = HttpContext.Session.GetString("AdminUsername");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UnlockScreen(string Email, string password)
        {
            if (HttpContext.Session.GetInt32("Adm_Id") == null)
            {
                return RedirectToAction("LoginAdmin", "Home");

            }
            int? adminId = HttpContext.Session.GetInt32("Adm_Id");
            // You can check if the session was previously set and is now locked
            var isLocked = HttpContext.Session.GetString("IsLocked");
            if (adminId != null && isLocked == "true" && _unitofWork.AdminLoginRepository.ValidateAdmin(Email, password, adminId.Value))
            {
                // Clear the locked state, but keep the session active
                HttpContext.Session.Remove("IsLocked");

                // Redirect to the secured page or dashboard
                return RedirectToAction("Index");
            }
            else
            {
                // Stay on the lock screen and show an error message if credentials are invalid
                ViewBag.ErrorMessage = "Invalid credentials or session not found";
                return View("LockScreen");
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
