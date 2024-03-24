using App.DataAccessLibrary.Infrastructure.IRepository;
using App.Models.Models;
using App.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Health_Insurance_MGMT.Controllers
{
    public class InsuranceController : Controller
    {

        private IUnitofWork _unitofWork;
        private IWebHostEnvironment _webHostEnvironment;

        public InsuranceController(IUnitofWork unitofWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitofWork = unitofWork;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: InsuranceController
        public ActionResult InsuranceView()
        {
            IEnumerable<InsuranceCompany> insuranceCompanies = _unitofWork.InsuranceCompanyRepository.GetAll();
            return View(insuranceCompanies);
        }

        // GET: InsuranceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InsuranceController/Create
        public ActionResult CreateInsurance()
        {
            return View();
        }

        // POST: InsuranceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateInsurance(InsuranceCompanyViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Ins_CompanyLogo != null && model.Ins_CompanyLogo.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", "InsuranceCompaniesData");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Ins_CompanyLogo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    Directory.CreateDirectory(uploadsFolder);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Ins_CompanyLogo.CopyToAsync(fileStream);
                    }
                }
                else
                {
                    // Handle the case when the logo is not uploaded
                    // You might want to set a default image or take some other action
                    uniqueFileName = "default-logo.png"; // Placeholder for a default image if necessary
                }

                InsuranceCompany insuranceCompany = new InsuranceCompany
                {
                    Ins_Name = model.Ins_Name,
                    Ins_Description = model.Ins_Description,
                    Address = model.Address,
                    Phone = model.Phone,
                    CompantWebsiteUrl = model.CompantWebsiteUrl,
                    Ins_CompanyLogourl = uniqueFileName
                };

                _unitofWork.InsuranceCompanyRepository.Add(insuranceCompany);
                // Inside your controller action
                await _unitofWork.save();

                return RedirectToAction("InsuranceView"); // Adjust the redirection as needed
            }

            return View(model);
        }


        // GET: InsuranceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InsuranceController/Edit/5
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

        // GET: InsuranceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InsuranceController/Delete/5
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
