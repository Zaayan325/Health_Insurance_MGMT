using App.DataAccessLibrary.Infrastructure.IRepository;
using App.Models.Models;
using App.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Common;
using System.Collections.Generic;

namespace Health_Insurance_MGMT.Controllers
{
    public class PoliciesRequestController : Controller
    {
        // GET: PoliciesRequestController
        private IUnitofWork _unitofWork;
        private IWebHostEnvironment _webHostEnvironment;

        public PoliciesRequestController(IUnitofWork unitofWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitofWork = unitofWork;
            _webHostEnvironment = webHostEnvironment;
        }


        // GET: PoliciesRequestController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PoliciesRequestController/Create
        
        public IActionResult CreateRequestByUser()
        {
            // Static status options
            var statusOptions = new List<SelectListItem>
    {
        new SelectListItem("Requested", "Requested"),
    };

            // Dynamic policy options from the database
            var policyOptions = _unitofWork.PoliciesRepository.GetAll()
                .Select(p => new SelectListItem
                {
                    Value = p.PolicyId.ToString(),
                    Text = p.PolicyName
                }).ToList();

            // Create and populate the combined view model
            var viewModel = new PolicyRequestDetailsViewModel
            {
                StatusOptions = statusOptions,
                PolicyOptions = policyOptions,
                
            };

            return View(viewModel);
        }



        // POST: PoliciesRequestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateRequestByUser(PolicyRequestDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Map the ViewModel to your domain model
                var requestDetails = new PolicyRequestDetails
                {
                    empno = model.empno, // This should ideally come from the logged-in user's session or similar
                    PolicyId = model.SelectedPolicy_Id,
                    Status = model.SelectedStatus,
                    RequestDate = DateTime.Now // Setting the request date to the current date
                };

                // Assuming you have a method in your unit of work to add a new request
                _unitofWork.PolicyRequestRepository.Add(requestDetails);
                _unitofWork.save();

                // Redirect to a confirmation page or back to the form with a success message
                return RedirectToAction("Index","Home");
            }

            // If we got this far, something failed, redisplay form
            // Reload necessary data for the form
            model.StatusOptions = new List<SelectListItem>
    {
        new SelectListItem("Requested", "Requested"),
    };
            model.PolicyOptions = _unitofWork.PoliciesRepository.GetAll()
                .Select(p => new SelectListItem
                {
                    Value = p.PolicyId.ToString(),
                    Text = p.PolicyName
                }).ToList();

            return View(model);
        }


        // GET: PoliciesRequestController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PoliciesRequestController/Edit/5
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

        // GET: PoliciesRequestController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PoliciesRequestController/Delete/5
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
