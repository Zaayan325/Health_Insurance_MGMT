using App.DataAccessLibrary.Infrastructure.IRepository;
using App.Models.Models;
using App.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        // GET: AdminLoginController
        public ActionResult AdminsView()
        {
            IEnumerable<AdminLogin> adminLogins = _unitofWork.AdminLoginRepository.GetAll();
            return View(adminLogins);
        }

        // GET: AdminLoginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminLoginController/Create
        public ActionResult CreateAdmin()
        {
            return View();
        }

        // POST: AdminLoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAdmin(AdminLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.AdminPhoto != null && model.AdminPhoto.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", "AdminData");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.AdminPhoto.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    Directory.CreateDirectory(uploadsFolder);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.AdminPhoto.CopyToAsync(fileStream);
                    }
                }
                else
                {
                    // Handle the case when the logo is not uploaded
                    // You might want to set a default image or take some other action
                    uniqueFileName = "default-logo.png"; // Placeholder for a default image if necessary
                }

                AdminLogin adminLogins = new AdminLogin
                {
                    AdminName = model.AdminName,
                    AdminPassword = model.AdminPassword,
                    ConfirmPassword =model.ConfirmPassword,
                    Address = model.Address,
                    Phone = model.Phone,
                    Email = model.Email,

                    
                    AdminPhotourl = uniqueFileName
                };

                _unitofWork.AdminLoginRepository.Add(adminLogins);
                // Inside your controller action
                await _unitofWork.save();

                return RedirectToAction("Dashboard","Admin"); // Adjust the redirection as needed
            }

            return View(model);
        }

        // GET: AdminLoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
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
