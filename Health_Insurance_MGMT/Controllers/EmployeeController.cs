using Microsoft.AspNetCore.Http;
using App.DataAccessLibrary.Infrastructure.IRepository;
using App.Models.Models;

using Microsoft.AspNetCore.Mvc;
using DocumentFormat.OpenXml.Office2013.PowerPoint.Roaming;
using Microsoft.AspNetCore.Mvc.Rendering;
using App.Models.ViewModels;

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
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeController/Create
       

        // POST: EmployeeController/Create
        

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeController/Edit/5
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
