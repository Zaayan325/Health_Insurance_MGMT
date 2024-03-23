using App.DataAccessLibrary.Infrastructure.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Health_Insurance_MGMT.Controllers
{
	public class ContactController : Controller
	{
		private IUnitofWork _unitofWork;
		public ContactController(IUnitofWork unitofWork)
        {
		 _unitofWork = unitofWork;
            
        }
        // GET: ContactController
        

		

		// GET: ContactController/Create
		

		// POST: ContactController/Create
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

		// GET: ContactController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: ContactController/Edit/5
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

		// GET: ContactController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: ContactController/Delete/5
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
}
