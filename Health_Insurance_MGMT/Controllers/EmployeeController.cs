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
        public IActionResult UpdateEmployee(int id)
        {
            var empRegister = _unitofWork.EmpRegisterRepository.GetT(emp => emp.empno == id);
            if (empRegister == null)
            {
                return NotFound();
            }

            // Create and populate the ViewModel
            var viewModel = new EmpRegisterViewModel
            {
                empno = empRegister.empno,
                designation = empRegister.designation,
                joindate = empRegister.joindate,
                Salary = empRegister.Salary,
                firstname = empRegister.firstname,
                lastname = empRegister.lastname,
                username = empRegister.username,
                password = empRegister.password,
                address = empRegister.address,
                contactno = empRegister.contactno,
                state = empRegister.state,
                country = empRegister.country,
                city = empRegister.city,
                policystatus = empRegister.policystatus,
                SelectedPolicyId = empRegister.PolicyId,
                PolicyOptions = _unitofWork.PoliciesRepository.GetAll()
                                 .Select(p => new SelectListItem { Value = p.PolicyId.ToString(), Text = p.PolicyName })
                                 .ToList()
            };

            return View(viewModel);
        }




        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateEmployee(EmpRegisterViewModel viewModel) // Marked as async
        {
            if (ModelState.IsValid)
            {
                var empRegister = _unitofWork.EmpRegisterRepository.GetT(emp => emp.empno == viewModel.empno);
                if (empRegister == null)
                {
                    return NotFound();
                }

                // Map updated properties from ViewModel to Domain Model
                empRegister.designation = viewModel.designation;
                empRegister.joindate = viewModel.joindate;
                empRegister.Salary = viewModel.Salary;
                empRegister.firstname = viewModel.firstname;
                empRegister.lastname = viewModel.lastname;
                empRegister.username = viewModel.username;
                empRegister.password = viewModel.password;
                empRegister.address = viewModel.address;
                empRegister.contactno = viewModel.contactno;
                empRegister.state = viewModel.state;
                empRegister.country = viewModel.country;
                empRegister.city = viewModel.city;
                empRegister.policystatus = viewModel.policystatus;
                empRegister.PolicyId = viewModel.SelectedPolicyId;

                await _unitofWork.EmpRegisterRepository.UpdateAsync(empRegister); // Now correctly awaits the async method

                return RedirectToAction("Dashboard", "Admin");
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
