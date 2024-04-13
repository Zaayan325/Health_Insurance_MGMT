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


        public IActionResult ViewPolicyRequests()
        {

            if (HttpContext.Session.GetInt32("Adm_Id") == null)
            {
                return RedirectToAction("LoginAdmin", "Home");

            }
            IEnumerable<PolicyRequestDetails> policiesreq = _unitofWork.PolicyRequestRepository.GetAll();
            return View(policiesreq);
        }
        public IActionResult ApproveOrDisapprove(int id)
        {
            if (HttpContext.Session.GetInt32("Adm_Id") == null)
            {
                return RedirectToAction("LoginAdmin", "Home");

            }
            var policyRequest = _unitofWork.PolicyRequestRepository.GetT(pr => pr.RequestId == id);
            if (policyRequest == null)
            {
                return NotFound();
            }

            // Static status options
            var statusOptions = new List<SelectListItem>
    {
        new SelectListItem("Requested", "Requested"),
        new SelectListItem("Approved", "Approved"),
        new SelectListItem("Dis-Approved", "Dis-Approved"),
    };

            // Dynamic policy options from the database
            var policyOptions = _unitofWork.PoliciesRepository.GetAll()
                .Select(p => new SelectListItem { Value = p.PolicyId.ToString(), Text = p.PolicyName })
                .ToList();

            // Create and populate the ViewModel
            var viewModel = new PolicyRequestDetailsViewModel
            {
                RequestId = policyRequest.RequestId,
                
                SelectedPolicy_Id = policyRequest.PolicyId,
                SelectedStatus = policyRequest.Status,
                PolicyOptions = policyOptions,
                StatusOptions = statusOptions
            };

            return View(viewModel);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ApproveOrDisapprove(PolicyRequestDetailsViewModel viewModel)
        {
            if (HttpContext.Session.GetInt32("Adm_Id") == null)
            {
                return RedirectToAction("LoginAdmin", "Home");

            }
            if (ModelState.IsValid)
            {
                var policyRequest = _unitofWork.PolicyRequestRepository.GetT(pr => pr.RequestId == viewModel.RequestId);
                if (policyRequest == null)
                {
                    return NotFound();
                }

                // No file upload processing is needed here as we're updating policy request details

                // Update properties from ViewModel to Domain Model
                // Although typically not changed in an approval process
                policyRequest.PolicyId = viewModel.SelectedPolicy_Id;
                policyRequest.Status = viewModel.SelectedStatus;

                // Update the policy request in the database
                _unitofWork.PolicyRequestRepository.Update(policyRequest);
                _unitofWork.save(); // Make sure to call the save method to commit changes

                return RedirectToAction("Dashboard", "Admin"); // Redirect to the desired page after successful update
            }

            // Repopulate PolicyOptions and StatusOptions if model validation fails
            viewModel.PolicyOptions = _unitofWork.PoliciesRepository.GetAll()
                                         .Select(p => new SelectListItem
                                         {
                                             Value = p.PolicyId.ToString(),
                                             Text = p.PolicyName
                                         }).ToList();

            viewModel.StatusOptions = new List<SelectListItem>
    {
        new SelectListItem("Requested", "Requested"),
        new SelectListItem("Approved", "Approved"),
        new SelectListItem("Dis-Approved", "Dis-Approved"),
    };

            return View(viewModel);
        }






        // GET: PoliciesRequestController/Create

        public IActionResult CreateRequestByUser()
        {
            if (HttpContext.Session.GetInt32("User_Id") == null)
            {
                return RedirectToAction("LoginUser", "Home");

            }
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
            if (HttpContext.Session.GetInt32("User_Id") == null)
            {
                return RedirectToAction("LoginUser","Home");

            }
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


       //For checking that Policies of that whose Accepted and disapproved

        public IActionResult MyPolicyRequests(int id)
{
            if (HttpContext.Session.GetInt32("User_Id") == null)
            {
                return RedirectToAction("LoginUser", "Home");

            }
            // Replace this with the actual logic to get the current user's employee number
            var currentUserEmpNo = id; // This is just an example; adjust according to your auth system

    IEnumerable<PolicyRequestDetails> myRequests = _unitofWork.PolicyRequestRepository.GetAll()
        .Where(pr => pr.empno == currentUserEmpNo); // Filter requests by the current user's empno

    return View(myRequests);
}



        // GET: PoliciesRequestController/Delete/5
        public IActionResult DeleteRequestPolicy(int? id)
        {
            if (HttpContext.Session.GetInt32("Adm_Id") == null)
            {
                return RedirectToAction("LoginAdmin", "Home");

            }
            if (id == null || id == 0)
            {
                return NotFound();


            }
            var policiesreq = _unitofWork.PolicyRequestRepository.GetT(x => x.RequestId == id);


            if (policiesreq == null)
            {
                return NotFound();
            }

            return View(policiesreq);
        }



        // POST: PoliciesController/Delete/5
        [HttpPost, ActionName("DeleteRequestPolicy")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteRequestPolicyPost(int? id)
        {
            if (HttpContext.Session.GetInt32("Adm_Id") == null)
            {
                return RedirectToAction("LoginAdmin", "Home");

            }
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var policiesreq = _unitofWork.PolicyRequestRepository.GetT(x => x.RequestId == id);
            if (policiesreq == null)
            {
                return NotFound();
            }


            _unitofWork.PolicyRequestRepository.Delete(policiesreq);
            _unitofWork.save();


            return RedirectToAction("ViewPolicyRequests");
        }
    }
}
