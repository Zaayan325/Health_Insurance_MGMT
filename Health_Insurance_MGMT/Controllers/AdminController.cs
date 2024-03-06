using Microsoft.AspNetCore.Http;
﻿using App.DataAccessLibrary.Infrastructure.IRepository;
using App.Models.Models;
using DocumentFormat.OpenXml.Bibliography;
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEmp(EmpRegister empRegister)
        {
            if (ModelState.IsValid)
            {
                _unitofWork.EmpRegisterRepository.Add(empRegister);
                _unitofWork.save();
                return RedirectToAction();
            }
            return View();
        }

        public IActionResult ViewEmp()
        {
            //Select * from table EmpRegister
            IEnumerable<EmpRegister> empRegisters = _unitofWork.EmpRegisterRepository.GetAll();
            return View(empRegisters);
        }
        // This Method will only return view with selected EmpRegister
        public IActionResult Delete(int? empno)
        {
            if (empno == null || empno == 0)
            {
                return NotFound();
            }
            var empreg = _unitofWork.EmpRegisterRepository.GetT(er => er.empno == empno);
            if (empreg == null)
            {
                return NotFound();
            }
            return View(empreg);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteData(int? empno) 
        {
            var empreg = _unitofWork.EmpRegisterRepository.GetT(er => er.empno == empno);
            if (empreg == null) 
            {
                return NotFound();
            }
            _unitofWork.EmpRegisterRepository.Delete(empreg);
            _unitofWork.save();
            return RedirectToAction();
        }

        public IActionResult Edit(int? empno)
        {
            if(empno == null || empno == 0)
            {
                return NotFound();
            }
            var empreg = _unitofWork.EmpRegisterRepository.GetT(er => er.empno == empno);
            if(empreg == null)
            {
                return NotFound();
            }
            return View(empreg);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmpRegister empreg)
        {
            if (ModelState.IsValid)
            {
                _unitofWork.EmpRegisterRepository.Update(empreg);
                _unitofWork.save();
                return RedirectToAction();
            }
            return RedirectToAction();
        }
    }
}
