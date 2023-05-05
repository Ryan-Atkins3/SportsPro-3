using Case_Study_3_1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Case_Study_3_1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RegistrationController : Controller
    {
        private SportsProContext context { get; set; }

        public RegistrationController(SportsProContext ctx) => context = ctx;

        public IActionResult Index()
        {
            var vm = new RegistrationViewModel
            {
                Customers = context.Customers.OrderBy(c => c.LastName).ToList()
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult List(Customer customer)
        {
            if(customer.CustomerId == 0)
            {
                TempData["message"] = "You must select a Customer";
                return RedirectToAction("Index");
            }
            else
            {
                HttpContext.Session.SetInt32("custId", customer.CustomerId);
                return RedirectToAction("List", new { id = customer.CustomerId });
            }
        }

        [HttpGet]
        public IActionResult List(int id)
        {
            var customer = context.Customers.Find(id);
            if(customer == null)
            {
                TempData["message"] = "Customer was not found you must enter a customer.";
                return RedirectToAction("Index");
            } else
            {
                var vm = new RegistrationViewModel
                {
                    products = context.Products.OrderBy(p => p.ProductPrice).ToList(),
                    customer = customer,
                    customerProducts = context.Products.Include(p => p.Customers).Where(p => p.CustomerId == customer.CustomerId).ToList()
                };

                return View(vm);
            }
        }

        [HttpPost]
        public IActionResult Register(Product product)
        {
            int? custId = HttpContext.Session.GetInt32("custId");
            if (product == null)
            {
                TempData["message"] = "Product was not found please select a product";
                return RedirectToAction("Index");
            } else
            {
                var customer = context.Customers.Find(custId);
                customer.Products.Add(product);
                context.Customers.Update(customer);
                context.SaveChanges();
                return RedirectToAction("List", new {id = custId});
            }
        }

        
    }
}
