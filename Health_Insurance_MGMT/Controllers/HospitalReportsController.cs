using App.DataAccessLibrary.Infrastructure.IRepository;
using App.Models.Models;
using App.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NHibernate.Criterion;
using NuGet.Common;
using System.Collections.Generic;

namespace Health_Insurance_MGMT.Controllers
{
    public class HospitalReportsController : Controller
    {
        
        private IUnitofWork _unitofWork;
        private IWebHostEnvironment _webHostEnvironment;

        public HospitalReportsController(IUnitofWork unitofWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitofWork = unitofWork;
            _webHostEnvironment = webHostEnvironment;
        }

        //it is only for user for sending the Details of Hospital Documents that how he uses jhis policy

        public IActionResult CreateHospitalReport(int id)
        {
            if (HttpContext.Session.GetInt32("User_Id") != null)
            {
                var employee = _unitofWork.EmpRegisterRepository.GetT(emp => emp.empno == id);
                if (employee == null)
                {
                    return NotFound();
                }

                int? userId = HttpContext.Session.GetInt32("User_Id");
                int? policyId = HttpContext.Session.GetInt32("EmployeePolicy");

                // Pass session values to the view using ViewBag or ViewData
                ViewBag.UserId = userId;
                ViewBag.PolicyId = policyId;

                // Assuming you correctly retrieve the employee's number and policy ID here
                // The previous code was incorrect as it reassigned 'employee', which is not shown in the ViewModel snippet

                var statusOptions = new SelectList(new List<SelectListItem>
 {
     new SelectListItem("Requested", "Requested"),
     // Add more options as necessary
 }, "Value", "Text");

                var viewModel = new HospitalViewModel
                {
                    // Set the employee number and policy ID as needed
                    empno = employee.empno, // Corrected to set the integer employee number
                                            // Assume you set PolicyId the same way if you have the data
                    StatusReportOptions = statusOptions
                };

                return View("CreateHospitalReport", viewModel);
            }
            else
            {
                return RedirectToAction("LoginUser", "Home");
            }
        }
        private string ProcessFileUpload(IFormFile file, bool isDocument = false)
        {
            if (file != null && file.Length > 0)
            {
                // Base folder path for all hospital-related uploads
                string baseUploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", "Hospitaldata");
                // Determine specific subfolder based on file type
                string subFolder = isDocument ? "documents" : "billpictures";
                string specificFolder = Path.Combine(baseUploadFolder, subFolder);
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;

                // Verify document type if it's supposed to be a document upload
                if (isDocument)
                {
                    var allowedMimeTypes = new List<string> { "application/pdf", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" };
                    if (!allowedMimeTypes.Contains(file.ContentType))
                    {
                        throw new InvalidOperationException("Invalid file type. Only PDF and DOCX documents are allowed.");
                    }
                }

                // Ensure directory exists
                if (!Directory.Exists(specificFolder))
                {
                    Directory.CreateDirectory(specificFolder);
                }

                // Path where the file will be saved
                string filePath = Path.Combine(specificFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                // Return the relative path for the file
                return $"~/uploads/hospitaldata/{subFolder}/{uniqueFileName}";
            }

            return null; // Return null if no file was uploaded
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateHospitalReport(HospitalViewModel model)
        {
            if (HttpContext.Session.GetInt32("User_Id") == null)
            {
                return RedirectToAction("LoginUser");
            }



            // File Upload for the Bill Picture
            string billFilePath = ProcessFileUpload(model.BillPictureFile);

            // File Upload for Hospital Documents
            string documentFilePath = ProcessFileUpload(model.DocumentsFile, true);

            // Create a new Hospital object and map the data
            Hospital newHospital = new Hospital
            {
                HospitalName = model.HospitalName,
                HospitalAddress = model.HospitalAddress,
                HospitalContactNo = model.HospitalContactNo,
                ExpenseIncurred = model.ExpenseIncurred,
                StatusReport = model.StatusReport,
                FullBillPictureUrl = billFilePath,
                DocumentsUrl = documentFilePath,
                empno = model.empno,
                PolicyId = model.PolicyId,
                HospitalReportSended = DateTime.Now
            };

            _unitofWork.HospitalRepository.Add(newHospital);
            _unitofWork.save(); // Assuming this saves the changes to the database

            return RedirectToAction("Index", "Home"); // Redirect to a confirmation page or dashboard
        }





        // GET: HospitalReportsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HospitalReportsController/Delete/5
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
