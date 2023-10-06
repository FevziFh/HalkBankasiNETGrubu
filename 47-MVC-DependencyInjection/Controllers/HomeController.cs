using _47_MVC_DependencyInjection.Classes;
using _47_MVC_DependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _47_MVC_DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMyService _service;

        public HomeController(ILogger<HomeController> logger, IMyService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            _service.Add();
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