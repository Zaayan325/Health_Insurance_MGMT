using Microsoft.AspNetCore.Http;
﻿using App.DataAccessLibrary.Infrastructure.IRepository;
using App.Models.Models;

using Microsoft.AspNetCore.Mvc;

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
            return View();
        }

        //public Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary GetModelState()
        //{
        //    return ModelState;
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEmp(EmpRegister empRegister)
        {
            if (ModelState.IsValid)
            {
                _unitofWork.EmpRegisterRepository.Add(empRegister);
                _unitofWork.save();
                return RedirectToAction("Dashboard");
            }
            return View(empRegister);
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
