using System.Diagnostics;
using App.DataAccessLibrary.Infrastructure.IRepository;
using App.Models.Models;
using App.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Health_Insurance_MGMT.Controllers
{
    public class PoliciesController : Controller
    {


        private IUnitofWork _unitofWork;
        private IWebHostEnvironment _webHostEnvironment;

        public PoliciesController(IUnitofWork unitofWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitofWork = unitofWork;
            _webHostEnvironment = webHostEnvironment;
        }
        // GET: PoliciesController
        public IActionResult ViewPolicy()
        {
            IEnumerable<Policies> policies = _unitofWork.PoliciesRepository.GetAll();
            return View(policies);
        }

        // GET: PoliciesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PoliciesController/Create
        [HttpGet]
        public IActionResult CreatePolicy()
        {
            var insuranceCompanies = _unitofWork.InsuranceCompanyRepository.GetAll()
                .Select(i => new SelectListItem
                {
                    Value = i.Ins_Id.ToString(), // Use Ins_Name as the value to be consistent with your requirement
                    Text = i.Ins_Name
                }).ToList();

            var model = new PolicyCreationViewModel
            {
                InsuranceCompanies = insuranceCompanies
            };

            return View(model);
        }





        // POST: PoliciesController/Create
       // POST: PoliciesController/Create
[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult CreatePolicy(PolicyCreationViewModel model)
{
    if (ModelState.IsValid)
    {
        // Validate the SelectedIns_Id exists
        var insuranceCompanyExists = _unitofWork.InsuranceCompanyRepository
            .GetAll()
            .Any(i => i.Ins_Id == model.SelectedIns_Id);

        if (!insuranceCompanyExists)
        {
            ModelState.AddModelError("SelectedIns_Id", "The selected Insurance Company does not exist.");
            model.InsuranceCompanies = _unitofWork.InsuranceCompanyRepository.GetAll()
                .Select(i => new SelectListItem
                {
                    Value = i.Ins_Id.ToString(),
                    Text = i.Ins_Name
                }).ToList();
            return View(model);
        }

        string filePath = null;
        if (model.PolicyTermsAndConditions != null && model.PolicyTermsAndConditions.Length > 0)
        {
            // Define allowed MIME types for PDF and Word documents
            var allowedMimeTypes = new List<string>
            {
                "application/pdf",
                "application/msword",
                "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
            };

            if (!allowedMimeTypes.Contains(model.PolicyTermsAndConditions.ContentType))
            {
                ModelState.AddModelError("PolicyTermsAndConditions", "Invalid file type. Only PDF and Word documents are allowed.");
                model.InsuranceCompanies = _unitofWork.InsuranceCompanyRepository.GetAll()
                    .Select(i => new SelectListItem
                    {
                        Value = i.Ins_Id.ToString(),
                        Text = i.Ins_Name
                    }).ToList();
                return View(model);
            }

            // Proceed with file handling if the MIME type is valid
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", "PoliciesData");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.PolicyTermsAndConditions.FileName;
            filePath = Path.Combine(uploadsFolder, uniqueFileName);

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                model.PolicyTermsAndConditions.CopyTo(fileStream);
            }

            // Store the relative path in the database
            filePath = $"~/uploads/PoliciesData/{uniqueFileName}";
        }

        Policies newPolicy = new Policies
        {
            PolicyName = model.PolicyName,
            PolicyDescription = model.PolicyDescription,
            PolicyFullAmount = model.PolicyFullAmount,
            equatedmonthlyinstalment = model.EquatedMonthlyInstalment,
            policymonths = model.PolicyMonths,
            Ins_Id = model.SelectedIns_Id,
            MedicalId = model.MedicalId,
            PolicyTermasandConditionsurl = filePath
        };

        _unitofWork.PoliciesRepository.Add(newPolicy);
        _unitofWork.save();

        return RedirectToAction("Dashboard", "Admin");
    }
    // If ModelState is not valid, return the view with the model to display the form again.
    return View(model);
}


        //Downloading the Policies
        // GET: DownloadPolicyTerms
        public async Task<IActionResult> DownloadPolicyTerms(int policyId)
        {
            // Use GetTAsync to asynchronously get the policy by ID
            var policy = await _unitofWork.PoliciesRepository.GetTAsync(p => p.PolicyId == policyId);

            if (policy == null || string.IsNullOrWhiteSpace(policy.PolicyTermasandConditionsurl))
            {
                return NotFound("The requested file does not exist.");
            }

            var filePath = policy.PolicyTermasandConditionsurl;
            // Assuming filePath is stored as a relative path
            var physicalPath = Path.Combine(_webHostEnvironment.WebRootPath, filePath.TrimStart('~', '/').Replace('/', Path.DirectorySeparatorChar));

            if (!System.IO.File.Exists(physicalPath))
            {
                return NotFound("The requested file does not exist.");
            }

            var mimeType = "application/octet-stream"; // Determine MIME type appropriately
            var fileName = Path.GetFileName(physicalPath);
            return PhysicalFile(physicalPath, mimeType, fileName);
        }




        // GET: PoliciesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PoliciesController/Edit/5
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

		// GET: PoliciesController/Delete/5
		
		public IActionResult DeletePolicy(int? id)
        {
			if (id == null || id == 0)
			{
				return NotFound();


			}
			var policies = _unitofWork.PoliciesRepository.GetT(x => x.PolicyId == id);


			if (policies == null)
			{
				return NotFound();
			}

			return View(policies);
		}

		// POST: PoliciesController/Delete/5
		[HttpPost, ActionName("DeletePolicy")]
		[ValidateAntiForgeryToken]
		public IActionResult DeletePolicyPost(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			var policies = _unitofWork.PoliciesRepository.GetT(x => x.PolicyId == id);
			if (policies == null)
			{
				return NotFound();
			}

						
				_unitofWork.PoliciesRepository.Delete(policies);
				_unitofWork.save();
			
		
			return RedirectToAction("ViewPolicy");
		}

        //User can see Policies Here
        public ActionResult CheckPoliciesByUser()
        {
            IEnumerable<Policies> policies = _unitofWork.PoliciesRepository.GetAll();
            return View(policies);
        }
    }
}
