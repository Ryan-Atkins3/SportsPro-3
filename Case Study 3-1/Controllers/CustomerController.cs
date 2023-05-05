using Case_Study_3_1.Models;
using Case_Study_3_1.Models.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Case_Study_3_1.Controllers
{
    public class CustomerController : Controller
    {

        private SportsProContext context { get; set; }

        //public CustomerController(SportsProContext ctx) => context = ctx;

        private Repository<Customer> data { get; set; }

        private Repository<Country> countryData { get; set; }

        public CustomerController(SportsProContext ctx)
        {
            data = new Repository<Customer>(ctx);
            countryData = new Repository<Country>(ctx);
            context = ctx;
        }

        [Route("/customers")]
        [HttpGet]
        public IActionResult Index()
        {
            //var customers = context.Customers.OrderBy(c => c.FirstName).ToList();
            var customers = data.List(new QueryOptions<Customer>
            {
                OrderBy = c => c.FirstName
            });
            return View(customers);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Add()
        {
			//ViewBag.Countries = context.Countries.OrderBy(c => c.CountryName).ToList();
            ViewBag.Countries = countryData.List(new QueryOptions<Country>
            {
                OrderBy = c => c.CountryName
            });
			ViewBag.Action = "Add";
            return View("Edit", new Customer());
        }

        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Countries = countryData.List(new QueryOptions<Country>
            {
                OrderBy = c => c.CountryName
            });
            ViewBag.Action = "Edit";
            var customer = data.Get(id);
            return View(customer);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            int custId = customer.CustomerId;
            Customer newCustomer = customer;
            string msg = Validate.CheckCustomer(context, customer);
            if (!string.IsNullOrEmpty(msg) && ViewBag.Action == "Add")
            {
                ModelState.AddModelError(nameof(Customer.Email), msg);
            }
            if (ModelState.IsValid)
            {
                if (custId > 0)
                {
                    
                    data.Update(customer);
                    //context.Customers.Add(customer);
                }
                else if(custId== 0)
                {
                    data.Insert(newCustomer);
                }
                data.Save();
                //context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Action = (customer.CustomerId == 0) ? "Add" : "Edit";
				ViewBag.Countries = countryData.List(new QueryOptions<Country> { OrderBy = c => c.CountryName });
                return View(customer);
			}
        }

        [Authorize]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Action = "Delete";
            //var customer = context.Customers.Find(id);
            var customer = data.Get(id);
            return View(customer);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            //context.Customers.Remove(customer);
            //context.SaveChanges();
            data.Delete(customer);
            data.Save();
            return RedirectToAction("Index");
        }
    }
}
