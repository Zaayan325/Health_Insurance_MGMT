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
        public ActionResult DetailsInsurance(int id)
        {
            var insuranceCompany = _unitofWork.InsuranceCompanyRepository.GetT(emp => emp.Ins_Id == id);
            if (insuranceCompany == null)
            {
                return NotFound();
            }

            // The view name here should exactly match the file name of the view
            return View("DetailsInsurance", insuranceCompany);
        }

        // GET: InsuranceController/Create
        public ActionResult CreateInsurance()
        {
            return View();
        }

		// POST: InsuranceController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult CreateInsurance(InsuranceCompanyViewModel model)
		{
			if (ModelState.IsValid)
			{
				string uniqueFileName = null;
				if (model.Ins_CompanyLogo != null && model.Ins_CompanyLogo.Length > 0)
				{
					string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", "InsuranceCompaniesData");
					uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Ins_CompanyLogo.FileName;
					string filePath = Path.Combine(uploadsFolder, uniqueFileName);

					if (!Directory.Exists(uploadsFolder))
					{
						Directory.CreateDirectory(uploadsFolder);
					}

					using (var fileStream = new FileStream(filePath, FileMode.Create))
					{
						model.Ins_CompanyLogo.CopyTo(fileStream);
					}
				}
				else
				{
					// If a logo is not uploaded, you can handle it here
					uniqueFileName = "default-logo.png"; // Example placeholder for a default logo
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
				_unitofWork.save(); // Save the changes synchronously

				return RedirectToAction("InsuranceView"); // Adjust the redirection as needed
			}

			// If the model state is not valid, render the form again with the provided data
			return View(model);
		}



		// GET: InsuranceController/Edit/5
		// GET: InsuranceController/Edit/5
		public ActionResult EditInsurance(int id)
        {
            var insuranceCompany = _unitofWork.InsuranceCompanyRepository.GetT(i => i.Ins_Id == id);
            if (insuranceCompany == null)
            {
                return NotFound();
            }

            var model = new InsuranceCompanyViewModel
            {
                Ins_Name = insuranceCompany.Ins_Name,
                Ins_Description = insuranceCompany.Ins_Description,
                Address = insuranceCompany.Address,
                Phone = insuranceCompany.Phone,
                CompantWebsiteUrl = insuranceCompany.CompantWebsiteUrl,
                // Ins_CompanyLogo is not set because it's a file input, not a text input
            };

            return View(model);
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult EditInsurance(int id, InsuranceCompanyViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var insuranceCompany = _unitofWork.InsuranceCompanyRepository.GetT(i => i.Ins_Id == id);
			if (insuranceCompany == null)
			{
				return NotFound();
			}

			if (model.Ins_CompanyLogo != null && model.Ins_CompanyLogo.Length > 0)
			{
				string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", "InsuranceCompaniesData");
				string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Ins_CompanyLogo.FileName;
				string filePath = Path.Combine(uploadsFolder, uniqueFileName);
				Directory.CreateDirectory(uploadsFolder);

				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					model.Ins_CompanyLogo.CopyTo(fileStream);
				}
				insuranceCompany.Ins_CompanyLogourl = uniqueFileName; // Update the logo URL only if a new logo was uploaded
			}

			insuranceCompany.Ins_Name = model.Ins_Name;
			insuranceCompany.Ins_Description = model.Ins_Description;
			insuranceCompany.Address = model.Address;
			insuranceCompany.Phone = model.Phone;
			insuranceCompany.CompantWebsiteUrl = model.CompantWebsiteUrl;

			_unitofWork.InsuranceCompanyRepository.Update(insuranceCompany);
			_unitofWork.save(); // Save the changes synchronously

			return RedirectToAction("InsuranceView");
		}


		// GET: InsuranceController/Delete/5
		public IActionResult DeleteInsurance(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            
            
            }
            var insuranceCompany = _unitofWork.InsuranceCompanyRepository.GetT(x => x.Ins_Id == id);

            
            if (insuranceCompany == null)
            {
                return NotFound();
            }

            return View(insuranceCompany);
        }


        // POST: CategoryController/Delete/5
        [HttpPost, ActionName("DeleteInsurance")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteInsurancePOST(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var insuranceCompany = _unitofWork.InsuranceCompanyRepository.GetT(x => x.Ins_Id == id);
            if (insuranceCompany == null)
            {
                return NotFound();
            }

            _unitofWork.InsuranceCompanyRepository.Delete(insuranceCompany);
            _unitofWork.save();

            return RedirectToAction("InsuranceView");
        }
    }
}
