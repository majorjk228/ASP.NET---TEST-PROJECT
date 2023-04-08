using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Diagnostics;
using TEST_TPLUS.Domains;
using TEST_TPLUS.Models;

namespace TEST_TPLUS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

		private readonly DataManager dataManager; 

		public HomeController(ILogger<HomeController> logger, DataManager dataManager)
        {
            _logger = logger;
			this.dataManager = dataManager;
		}

        public IActionResult Index()
        {
            return View();
        }

		public IActionResult Privacy()
        {
            return View();
        }

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}