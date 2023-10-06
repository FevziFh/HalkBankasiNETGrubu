using _37_MVC_FirstWebPage.Models;
using Microsoft.AspNetCore.Mvc;

namespace _37_MVC_FirstWebPage.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //return Content("Merhaba MVC Dünya - ilk MVC Kodum");
            Movie movie = new Movie() { Id=1,Title="The Godfather",ReleaseDate=new DateTime(1972,2,24)};
            return View(movie);
        }
        public IActionResult Create()
        {
            return Content("Oluşturuldu");
        }
    }
}
