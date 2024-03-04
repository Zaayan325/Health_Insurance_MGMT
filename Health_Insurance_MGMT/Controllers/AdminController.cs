<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Http;
=======
﻿using App.DataAccessLibrary.Infrastructure.IRepository;
using App.Models.Models;
>>>>>>> 677ac013035c8a5af3955961ab568527c8581c0d
using Microsoft.AspNetCore.Mvc;

namespace Health_Insurance_MGMT.Controllers
{
<<<<<<< HEAD
	public class AdminController : Controller
	{
		// GET: AdminController
		[Route("/dashboard")]
		public ActionResult Dashboard()
		{
			return View();
		}

		// GET: AdminController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: AdminController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: AdminController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
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

		// GET: AdminController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: AdminController/Edit/5
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

		// GET: AdminController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: AdminController/Delete/5
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
=======
    public class AdminController : Controller
    {
        private IUnitofWork _unitofWork;
        private IWebHostEnvironment _webHostEnvironment;

        public AdminController(IUnitofWork unitofWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitofWork = unitofWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        //This Method will Only return view
        public IActionResult EmpRegister()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EmpRegister(EmpRegister empRegister)
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
    }
>>>>>>> 677ac013035c8a5af3955961ab568527c8581c0d
}
