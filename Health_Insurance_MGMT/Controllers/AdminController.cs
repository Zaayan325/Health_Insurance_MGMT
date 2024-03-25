using Microsoft.AspNetCore.Http;
﻿using App.DataAccessLibrary.Infrastructure.IRepository;
using App.Models.Models;

using Microsoft.AspNetCore.Mvc;
using DocumentFormat.OpenXml.Office2013.PowerPoint.Roaming;
using Microsoft.AspNetCore.Mvc.Rendering;
using App.Models.ViewModels;

namespace Health_Insurance_MGMT.Controllers
{

    public class AdminController : Controller
    {
        private IUnitofWork _unitofWork;
        private IWebHostEnvironment _webHostEnvironment;

        public AdminController(IUnitofWork unitofWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitofWork = unitofWork;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: AdminController
        [Route("/dashboard")]
        public ActionResult Dashboard()
        {
            int employeeCount = _unitofWork.EmpRegisterRepository.GetAll().Count();

            // Storing the count in TempData
            TempData["EmployeeCount"] = employeeCount;

            return View();
        }
        //This Method will Only return view


        public IActionResult AddEmp()
        {
            var policies = _unitofWork.PoliciesRepository.GetAll()
        .Select(p => new SelectListItem
        {
            Value = p.PolicyId.ToString(),
            Text = p.PolicyName
        }).ToList();

            // Create and populate the ViewModel
            var viewModel = new EmpRegisterViewModel
            {
                PolicyOptions = policies
            };
            return View(viewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEmp(EmpRegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Map ViewModel to Domain Model
                var empRegister = new EmpRegister
                {
                    // Map each property from viewModel to empRegister
                    empno = viewModel.empno,
                    designation = viewModel.designation,
                    joindate = viewModel.joindate,
                    Salary = viewModel.Salary,
                    firstname = viewModel.firstname,
                    lastname = viewModel.lastname,
                    username = viewModel.username,
                    password = viewModel.password,
                    address = viewModel.address,
                    contactno = viewModel.contactno,
                    state = viewModel.state,
                    country = viewModel.country,
                    city = viewModel.city,
                    policystatus = viewModel.policystatus,
                    PolicyId = viewModel.SelectedPolicyId, // Set PolicyId from the selected value
                };

                _unitofWork.EmpRegisterRepository.Add(empRegister);
                _unitofWork.save();
                return RedirectToAction("Dashboard");
            }

            // If we get here, something was wrong with the model,
            // Repopulate PolicyOptions before returning the view.
            viewModel.PolicyOptions = _unitofWork.PoliciesRepository.GetAll()
                .Select(p => new SelectListItem
                {
                    Value = p.PolicyId.ToString(),
                    Text = p.PolicyName
                }).ToList();

            return View(viewModel);
        }



        public IActionResult ViewEmp()
        {
            //Select * from table EmpRegister
            IEnumerable<EmpRegister> empRegisters = _unitofWork.EmpRegisterRepository.GetAll();
            return View(empRegisters);
        }
        // This Method will only return view with selected EmpRegister
       

      

     

       


        //For Accesing The Contacts 
        public IActionResult ViewContacts()
        {
            IEnumerable<Contact> contacts = _unitofWork.ContactRepository.GetAll();
            return View(contacts);
        }
        //For deleting the category
        // DeleteContact

        public IActionResult DeleteContact(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var contactss = _unitofWork.ContactRepository.GetT(x => x.Contact_Id == id);
            if (contactss == null)
            {
                return NotFound();

            }
            return View(contactss);
        }

        // POST: CategoryController/Delete/5

        [HttpPost, ActionName("DeleteContact")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteContact(int id)
        {
            var category = _unitofWork.ContactRepository.GetT(x => x.Contact_Id == id);
            if (category == null)
            {
                return BadRequest();
            }
            _unitofWork.ContactRepository.Delete(category);
            _unitofWork.save();

            return RedirectToAction("Dashboard");

            //We can also do that  return RedirectToAction("Action Name","Controller NAme");


        }

    }
}
