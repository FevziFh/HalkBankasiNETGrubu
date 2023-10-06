using _48_MVC_ETrade.Models;
using _48_MVC_ETrade.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _48_MVC_ETrade.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepo _repo;

        public HomeController(ILogger<HomeController> logger,IProductRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            var products = _repo.GetAllProduct();
            return View(products);
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