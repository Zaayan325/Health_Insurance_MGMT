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
        public ActionResult EditAdmin(int id)
        {
            var adminLogin = _unitofWork.AdminLoginRepository.GetT(u => u.Adm_ID == id);
            if (adminLogin == null)
            {
                return NotFound();
            }

            var model = new AdminLoginViewModel
            {
                Adm_ID = adminLogin.Adm_ID,
                AdminName = adminLogin.AdminName,
                Email = adminLogin.Email,
                Address = adminLogin.Address,
                Phone = adminLogin.Phone,
                AdminPassword   = adminLogin.AdminPassword,
                ConfirmPassword = adminLogin.ConfirmPassword,
                // Note: You do not need to set password or confirm password for edit
                AdminAdded = adminLogin.AdminAdded,
                // AdminPhoto can be handled separately if you want to display it or allow changing it
            };

            return View(model);
        }

        // POST: AdminLoginController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAdmin(AdminLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var adminLogin = _unitofWork.AdminLoginRepository.GetT(u => u.Adm_ID == model.Adm_ID);
                if (adminLogin != null)
                {
                    // Update the properties
                    adminLogin.AdminName = model.AdminName;
                    adminLogin.Email = model.Email;
                    adminLogin.Address = model.Address;
                    adminLogin.Phone = model.Phone;
                    adminLogin.AdminPassword = model.AdminPassword;
                    adminLogin.ConfirmPassword = model.ConfirmPassword;

                    // Handle AdminPhoto update if necessary
                    if (model.AdminPhoto != null && model.AdminPhoto.Length > 0)
                    {
                        // Assuming you want to replace the old file, you might also want to delete it from the server
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", "AdminData");
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.AdminPhoto.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        // If there's an old photo and it's not the default, consider deleting it if appropriate
                        if (!string.IsNullOrEmpty(adminLogin.AdminPhotourl) && adminLogin.AdminPhotourl != "default-photo.png")
                        {
                            string oldFilePath = Path.Combine(uploadsFolder, adminLogin.AdminPhotourl);
                            if (System.IO.File.Exists(oldFilePath))
                            {
                                System.IO.File.Delete(oldFilePath);
                            }
                        }

                        // Save the new photo
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            model.AdminPhoto.CopyTo(fileStream);
                        }

                        adminLogin.AdminPhotourl = uniqueFileName; // Update the photo URL in the database
                    }

                    _unitofWork.AdminLoginRepository.Update(adminLogin);
                    _unitofWork.save();

                    return RedirectToAction("AdminsView");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        // GET: AdminLoginController/Delete/5
        public ActionResult DeleteAdmin(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();


            }
            var adminlogin = _unitofWork.AdminLoginRepository.GetT(x => x.Adm_ID == id);


            if (adminlogin == null)
            {
                return NotFound();
            }
			var totalAdmins = _unitofWork.AdminLoginRepository.GetAll().Count();
			if (totalAdmins <= 2)
			{
				// Optionally, use TempData to pass an alert message to the view if there are too few admins to allow deletion
				TempData["AlertMessage"] = "Cannot delete the admin. There must be at least 2 admins at all times.";
				return RedirectToAction("AdminsView"); // Redirect to the list of admins or a relevant view
			}

			return View(adminlogin);
        }

		// POST: AdminLoginController/Delete/5
		[HttpPost, ActionName("DeleteAdmin")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteAdminPOST(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			var adminLogin = _unitofWork.AdminLoginRepository.GetT(x => x.Adm_ID == id);
			if (adminLogin == null)
			{
				return NotFound();
			}

			// Check the total number of admins again in case the situation has changed since the GET request
			var totalAdmins = _unitofWork.AdminLoginRepository.GetAll().Count();
			if (totalAdmins <= 2)
			{
				// Optionally, use TempData to pass an alert message back to the view
				TempData["AlertMessage"] = "Cannot delete the admin. There must be at least 2 admins at all times.";
				return RedirectToAction("AdminsView"); // Redirect to the list of admins or a relevant view
			}

			_unitofWork.AdminLoginRepository.Delete(adminLogin);
			_unitofWork.save();

			return RedirectToAction("AdminsView"); // Adjust this to wherever you want the user to go after deleting an admin
		}

     


    }
}
