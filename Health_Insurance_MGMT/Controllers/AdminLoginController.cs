using App.DataAccessLibrary.Infrastructure.IRepository;
using App.DataAccessLibrary.Infrastructure.Repository;
using App.Models.Models;
using App.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Health_Insurance_MGMT.Controllers
{
    public class AdminLoginController : Controller
    {

        private IUnitofWork _unitofWork;
        private IWebHostEnvironment _webHostEnvironment;

        public AdminLoginController(IUnitofWork unitofWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitofWork = unitofWork;
            _webHostEnvironment = webHostEnvironment;
        }

       
       
        // GET: AdminLoginController/Create
        public ActionResult CreateAdmin()
        {
            return View();
        }

		// POST: AdminLoginController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult CreateAdmin(AdminLoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				string uniqueFileName = null;
				if (model.AdminPhoto != null && model.AdminPhoto.Length > 0)
				{
					string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", "AdminData");
					uniqueFileName = Guid.NewGuid().ToString() + "_" + model.AdminPhoto.FileName;
					string filePath = Path.Combine(uploadsFolder, uniqueFileName);

					// Ensure the uploads directory exists
					Directory.CreateDirectory(uploadsFolder);

					// Write the file to the server
					using (var fileStream = new FileStream(filePath, FileMode.Create))
					{
						model.AdminPhoto.CopyTo(fileStream);
					}
				}
				else
				{
					// Handle the case when the admin photo is not uploaded
					// You can assign a default image or handle accordingly
					uniqueFileName = "default-photo.png"; // Placeholder for a default image if necessary
				}

				AdminLogin adminLogins = new AdminLogin
				{
					AdminName = model.AdminName,
					AdminPassword = model.AdminPassword,
					ConfirmPassword = model.ConfirmPassword,
					Address = model.Address,
					Phone = model.Phone,
					Email = model.Email,
					AdminPhotourl = uniqueFileName
				};

				_unitofWork.AdminLoginRepository.Add(adminLogins);
				// Synchronously save the changes to the database
				_unitofWork.save();

				return RedirectToAction("Dashboard", "Admin"); // Adjust the redirection as needed
			}

			// If the ModelState is not valid, the form is presented again with validation messages
			return View(model);
		}

		// GET: AdminLoginController/Edit/5
		public ActionResult AdminsView()
        {
            IEnumerable<AdminLogin> adminslogedin = _unitofWork.AdminLoginRepository.GetAll();
            return View(adminslogedin);
            
        }

        // POST: AdminLoginController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminLoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminLoginController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
