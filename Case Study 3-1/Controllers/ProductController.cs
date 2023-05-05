  using Microsoft.AspNetCore.Mvc;
using Case_Study_3_1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Case_Study_3_1.Controllers
{
	public class ProductController : Controller
	{

		private SportsProContext context { get; set; }

		public ProductController(SportsProContext ctx) => context = ctx;

		[Route("/products")]
		[HttpGet]
		public IActionResult Index()
		{
			var products = context.Products.OrderBy(p => p.ProductReleaseDate).ToList();
			return View(products);
		}

        [Authorize]
        [HttpGet]
		public IActionResult Add()
		{
			ViewBag.Action = "Add";
			return View("Edit", new Product());
		}

        [Authorize]
        [HttpGet]
		public IActionResult Edit(int id)
		{
			ViewBag.Action = "Edit";
			var product = context.Products.Find(id);
			return View(product);
		}

        [Authorize]
        [HttpPost]
		public IActionResult Edit(Product product)
		{
			if (ModelState.IsValid)
			{
				if (product.ProductId == 0)
				{
					context.Products.Add(product);
				} else
				{
					context.Products.Update(product);
				}
				context.SaveChanges();
				TempData["message"] = $"{product.ProductName} was added!";
				return RedirectToAction("Index");
			} else
			{
				ViewBag.Action = (product.ProductId == 0) ? "Add" : "Edit";
				return View(product);
			}
		}

        [Authorize]
        [HttpGet]
		public IActionResult Delete(int id)
		{
			ViewBag.Action = "Delete";
			var product = context.Products.Find(id);
			return View(product);
		}

        [Authorize]
        [HttpPost]
		public IActionResult Delete(Product product)
		{
			context.Products.Remove(product);
			context.SaveChanges(); 
			return RedirectToAction("Index");
		}
	}
}
