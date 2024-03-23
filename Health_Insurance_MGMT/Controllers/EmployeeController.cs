using Microsoft.AspNetCore.Http;
using App.DataAccessLibrary.Infrastructure.IRepository;
using App.Models.Models;

using Microsoft.AspNetCore.Mvc;
using DocumentFormat.OpenXml.Office2013.PowerPoint.Roaming;
using Microsoft.AspNetCore.Mvc.Rendering;
using App.Models.ViewModels;
using App.DataAccessLibrary.Infrastructure.Repository;

namespace Health_Insurance_MGMT.Controllers
{
    public class EmployeeController : Controller
    {
        private IUnitofWork _unitofWork;
        
        public EmployeeController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
            
        }


        // GET: EmployeeController/Details/5
        public ActionResult DetailsEmployee(int id)
        {
            var employee = _unitofWork.EmpRegisterRepository.GetT(emp => emp.empno == id);
            if (employee == null)
            {
                return NotFound();
            }

            // The view name here should exactly match the file name of the view
            return View("DetailsEmployee", employee);
        }


        // GET: EmployeeController/Create


        // POST: EmployeeController/Create


        // GET: EmployeeController/Edit/5
        [HttpGet]
        public IActionResult UpdateEmployee(int id)
        {
            var empRegister = _unitofWork.EmpRegisterRepository.GetT(emp => emp.empno == id);
            if (empRegister == null)
            {
                return NotFound();
            }

            return View(empRegister);
        }


        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken,ActionName("UpdateEmployee")] // Helps to prevent CSRF attacks
        public IActionResult UpdateEmployee(EmpRegister empRegister)
        {
            if (ModelState.IsValid) 
            {
                _unitofWork.EmpRegisterRepository.Update(empRegister);
                _unitofWork.save();
                return RedirectToAction("ViewEmp", "Admin");
                //return RedirectToAction("DetailsEmployee", new { id = empRegister.empno });
            }

            return View(empRegister); 
        }


        // GET: EmployeeController/Delete/5
        public IActionResult DeleteEmployee(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var employee = _unitofWork.EmpRegisterRepository.GetT(x => x.empno == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }


        // POST: CategoryController/Delete/5
        [HttpPost, ActionName("DeleteEmployee")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEmployeePOST(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var employee = _unitofWork.EmpRegisterRepository.GetT(x => x.empno == id);
            if (employee == null)
            {
                return NotFound();
            }

            _unitofWork.EmpRegisterRepository.Delete(employee);
            _unitofWork.save();

            return RedirectToAction("Dashboard", "Admin");
        }

    }
}
