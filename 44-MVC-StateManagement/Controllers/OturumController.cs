using Microsoft.AspNetCore.Mvc;

namespace _44_MVC_StateManagement.Controllers
{
    public class OturumController : Controller
    {
        const string personelAdi = "ad";
        const string personelMaili = "mail";
        const string personelYasi = "yasi";
        const string personelRolu = "rol";
        public IActionResult Index()
        {
            HttpContext.Session.SetString(personelAdi, "Bilge Adam");
            HttpContext.Session.SetInt32(personelYasi, 18);
            HttpContext.Session.SetString(personelMaili, "bilgeadam@mail.com");
            HttpContext.Session.SetString(personelRolu, "user");

            return View();
        }

        public IActionResult Oturum()
        {
            ViewBag.prsAdi = HttpContext.Session.GetString(personelAdi);
            ViewBag.prsMaili= HttpContext.Session.GetString(personelMaili);
            ViewBag.prsRol = HttpContext.Session.GetString(personelRolu);
            ViewBag.prsYas = HttpContext.Session.GetInt32(personelYasi);

            return View();
        }
    }

}
