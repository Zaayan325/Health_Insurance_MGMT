using App.DataAccessLibrary.Infrastructure.IRepository;
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
    }
}
