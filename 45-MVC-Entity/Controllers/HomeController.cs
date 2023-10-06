using _45_MVC_Entity.Models;
using _45_MVC_Entity.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _45_MVC_Entity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryRepo _repo;

        public HomeController(ILogger<HomeController> logger, ICategoryRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Category category)
        {
            _repo.AddCategory(category);
            return Content("Başarılı bir şekilde eklendi");
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