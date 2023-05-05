using Case_Study_3_1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Case_Study_3_1.Controllers
{

    public class IncidentsController : Controller
    {
        private SportsProContext context { get; set; }

        public IncidentsController(SportsProContext ctx) => context = ctx;

        //private Repository<Activity> data { get; set; }

        //public IncidentsController(SportsProContext ctx)
        //{
        //    data = new Repository<Activity>(ctx);
        //}

        [Route("/incidents/{id}")]
		[Route("/incidents")]
        public IActionResult Index(string id)
        {
            if(id == "Un")
            {
                var vm = new IncidentsViewModel();
                vm.Incidents = context.Incidents.Where(i => i.TechnicianId < 0).Include(c => c.Customer).Include(i => i.Technician).Include(i => i.Product).OrderBy(i => i.Title).ToList();
                vm.Customers = context.Customers.OrderBy(c => c.LastName).ToList();
                vm.Technicians = context.Technicians.OrderBy(t => t.TechnicianName).ToList();
                vm.Products = context.Products.OrderBy(p => p.ProductName).ToList();
                return View(vm);
            }
            else if(id == "Op")
            {
                var vm = new IncidentsViewModel();
                vm.Incidents = context.Incidents.Where(i => i.DateClosed == null).Include(c => c.Customer).Include(i => i.Technician).Include(i => i.Product).OrderBy(i => i.Title).ToList();
                vm.Customers = context.Customers.OrderBy(c => c.LastName).ToList();
                vm.Technicians = context.Technicians.OrderBy(t => t.TechnicianName).ToList();
                vm.Products = context.Products.OrderBy(p => p.ProductName).ToList();
                return View(vm);
            }
            else
            {
                var vm = new IncidentsViewModel();
                vm.Incidents = context.Incidents.Include(c => c.Customer).Include(i => i.Technician).Include(i => i.Product).OrderBy(i => i.Title).ToList();
                vm.Customers = context.Customers.OrderBy(c => c.LastName).ToList();
                vm.Technicians = context.Technicians.OrderBy(t => t.TechnicianName).ToList();
                vm.Products = context.Products.OrderBy(p => p.ProductName).ToList();
                return View(vm);
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult Add()
        {
            var vm = new IncidentsViewModel();
            vm.incident = new Incident();
            vm.Incidents = context.Incidents.OrderBy(i => i.Title).ToList();
            vm.Customers = context.Customers.OrderBy(c => c.LastName).ToList();
            vm.Technicians = context.Technicians.OrderBy(t => t.TechnicianName).ToList();
            vm.Products = context.Products.OrderBy(p => p.ProductName).ToList();
            vm.Operation = "Add";
            return View("Edit", vm);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
		{
			var vm = new IncidentsViewModel();
			vm.incident = context.Incidents.Find(id)!;
			vm.Incidents = context.Incidents.OrderBy(i => i.Title).ToList();
			vm.Customers = context.Customers.OrderBy(c => c.LastName).ToList();
			vm.Technicians = context.Technicians.OrderBy(t => t.TechnicianName).ToList();
			vm.Products = context.Products.OrderBy(p => p.ProductName).ToList();
			vm.Operation = "Edit";
            return View(vm);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(IncidentsViewModel i)
        {
            if (ModelState.IsValid)
            {
                if (i.incident.IncidentId == 0)
                {
                    context.Add(i.incident);
                } else
                {
                    context.Update(i.incident);
                }
                context.SaveChanges();
                return RedirectToAction("Index"); 
            } else
            {
                ViewBag.Action = (i.incident.IncidentId == 0) ? "Add" : "";
				ViewBag.Customers = context.Customers.ToList();
				ViewBag.Products = context.Products.ToList();
				ViewBag.Technicians = context.Technicians.ToList();
				return View(i);
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Action = "Delete";
            var i = context.Incidents.Find(id);
            return View(i);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete(Incident incident)
        {
            context.Incidents.Remove(incident);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
