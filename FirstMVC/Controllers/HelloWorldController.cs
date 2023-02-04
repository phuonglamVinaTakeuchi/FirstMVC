using FirstMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVC.Controllers
{
	public class HelloWorldController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		private static readonly List<DogViewModel> _dogs = new();

		public HelloWorldController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View(_dogs);
		}

		[HttpGet]
		public IActionResult Create()
		{
			var dog = new DogViewModel();
			return View(dog);
		}

		[HttpPost]
		public IActionResult Create(DogViewModel dogViewModel)
		{
			_dogs.Add(dogViewModel);
			return RedirectToAction(nameof(Index));
		}
	}
}
