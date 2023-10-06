using Microsoft.AspNetCore.Mvc;

namespace _40_MVC_TempData.Controllers
{
    public class DenemeController : Controller
    {
        public IActionResult Index()
        {
            //ViewBag.Deneme = "Deneme Yazı";
            //var denemeMessage = ViewBag.Deneme;

            TempData["ErorMessage"] = "Hata Gerçekleşti.";
            return RedirectToAction("Eror");
        }
        public IActionResult Eror()
        {
            //var denemeMessage = ViewBag.Deneme;
            //var erorMessage = TempData["ErorMessage"] as string;
            //TempData.Keep("ErorMessage");

            var erorMessage = TempData.Peek("ErorMessage") as string;
            return Content(erorMessage);
        }
    }
}
