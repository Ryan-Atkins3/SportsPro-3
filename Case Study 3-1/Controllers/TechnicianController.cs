using Case_Study_3_1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Case_Study_3_1.Controllers
{
	public class TechnicianController : Controller
	{

		private SportsProContext context { get; set; }

		public TechnicianController(SportsProContext ctx) => context = ctx;

		[Route("/technicians")]
		[HttpGet]
		public IActionResult Index()
		{
			var technicians = context.Technicians.Where(t=>t.TechnicianId>0).OrderBy(t => t.TechnicianName).ToList();
			return View(technicians);
		}

        [Authorize]
        [HttpGet]
		public IActionResult Add()
		{
			ViewBag.Action = "Add";
			return View("Edit", new Technician());
		}

        [Authorize]
        [HttpGet]
		public IActionResult Edit(int id)
		{
			ViewBag.Action = "Edit";
			var technician = context.Technicians.Find(id);
			return View(technician);
		}

        [Authorize]
        [HttpPost]
		public IActionResult Edit(Technician technician)
		{
			if (ModelState.IsValid)
			{
				if(technician.TechnicianId== 0)
				{
					context.Technicians.Add(technician);
				} else
				{
					context.Technicians.Update(technician);
				}
				context.SaveChanges();
				return RedirectToAction("Index");
			}
			else
			{
				ViewBag.Action = (technician.TechnicianId == 0) ? "Add" : "Edit";
				return View(technician);
			}
		}

        [Authorize]
        [HttpGet]
		public IActionResult Delete(int id)
		{
			ViewBag.Action = "Delete";
			var technician = context.Technicians.Find(id);
			return View(technician);
		}

        [Authorize]
        [HttpPost]
		public IActionResult Delete(Technician technician)
		{
			context.Technicians.Remove(technician);
			context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
