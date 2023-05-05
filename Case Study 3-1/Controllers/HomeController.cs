using Microsoft.AspNetCore.Mvc;

namespace Case_Study_3_1.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		[Route("/about")]
		public IActionResult About()
		{
			return View();
		}
	}
}
