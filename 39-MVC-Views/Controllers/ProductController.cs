using _39_MVC_Views.Models;
using Microsoft.AspNetCore.Mvc;

namespace _39_MVC_Views.Controllers
{
    public class ProductController : Controller
    {
        IList<Product> products = new List<Product>()
        {
            new Product{ Id = 1,Title="Kalem-1",Price=50},
            new Product{ Id = 2,Title="Kalem-2",Price=65},
            new Product{ Id = 3,Title="Kalem-3",Price=45},
            new Product{ Id = 4,Title="Kalem-4",Price=35},
            new Product{ Id = 5,Title="Kalem-5",Price=55},
            new Product{ Id = 6,Title="Kalem-6",Price=75}
        };
        public IActionResult Index()
        {
            ViewBag.Subject = "Productların ViewBag ile getir";
            ViewBag.Products = products;

            ViewData["Subject"] = "Productların ViewBag ile getir";
            ViewData["Subject2"] = products;

            return View(products);
        }
        public IActionResult Detail(int id)
        {
            //return Content(id.ToString());
            var product = products.FirstOrDefault(x => x.Id == id);
            return View(product);
        }
    }
}
