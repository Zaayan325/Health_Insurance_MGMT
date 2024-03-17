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
            return View();
        }
        //This Method will Only return view
   
        public IActionResult AddEmp()
        {
            return View();
        }

        public Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary GetModelState()
        {
            return ModelState;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEmp(EmpRegister empRegister, Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary modelState)
        {
            if (modelState.IsValid)
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
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var empreg = _unitofWork.EmpRegisterRepository.GetT(er => er.empno == id);
            if (empreg == null)
            {
                return NotFound();
            }
            return View(empreg);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteData(int? id) 
        {
            var empreg = _unitofWork.EmpRegisterRepository.GetT(er => er.empno == id);
            if (empreg == null) 
            {
                return NotFound();
            }
            _unitofWork.EmpRegisterRepository.Delete(empreg);
            _unitofWork.save();
            return RedirectToAction("ViewEmp");
        }
        public IActionResult EditEmp(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var emp = _unitofWork.EmpRegisterRepository.GetT(e => e.empno == id);

            

            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditEmp(EmpRegister empRegister)
        {
            if (ModelState.IsValid)
            {
                _unitofWork.EmpRegisterRepository.Update(empRegister);
                _unitofWork.save();
                return RedirectToAction("ViewEmp");
            }
            return RedirectToAction("ViewEmp");
        }

		//Company Details CRUD

		public IActionResult AddCompany()
        {
           return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
		public IActionResult AddCompany(CompanyDetails companyDetails)
        {
            if (ModelState.IsValid)
            {
                _unitofWork.CompanyDetailsRepository.Add(companyDetails);
                _unitofWork.save();
                return RedirectToAction("Dashboard");
            }
            return View(companyDetails);
        }

        public IActionResult viewcompany()
        {
            IEnumerable<CompanyDetails> companyDetails  = _unitofWork.CompanyDetailsRepository.GetAll();
            return View(companyDetails);
        }

        public IActionResult deletecompany(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var companyd = _unitofWork.CompanyDetailsRepository.GetT(cd => cd.CompanyId == id);
            if (companyd == null)
            {
                return NotFound();
            }
            return View(companyd);
        }

        [HttpPost, ActionName("deletecompany")]
        [ValidateAntiForgeryToken]
        public IActionResult Deletec(int? id)
        {
            var companyd = _unitofWork.CompanyDetailsRepository.GetT(cd => cd.CompanyId == id);
            if (companyd == null)
            {
                return NotFound();
            }
            _unitofWork.CompanyDetailsRepository.Delete(companyd);
            _unitofWork.save();
            return RedirectToAction();
        }

        public IActionResult EditCompany(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var company = _unitofWork.CompanyDetailsRepository.GetT(x => x.CompanyId == id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCompany(CompanyDetails companyDetails)
        {
            if (ModelState.IsValid)
            {
                _unitofWork.CompanyDetailsRepository.Update(companyDetails);
                _unitofWork.save();
                return RedirectToAction("ViewCompany");
            }
            return View(companyDetails);
        }
    }
}
