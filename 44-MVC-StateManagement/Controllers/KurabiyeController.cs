using Microsoft.AspNetCore.Mvc;

namespace _44_MVC_StateManagement.Controllers
{
    public class KurabiyeController : Controller
    {
        public string KurabiyeGetir(string Kurabiye)
        {
            HttpContext.Request.Cookies.TryGetValue(Kurabiye, out var cookies);
            return cookies;
        }
        public IActionResult Index()
        {
            HttpContext.Response.Cookies.Append("Ad", "BilgeAdam");
            HttpContext.Response.Cookies.Append("Yasi", "25");

            return View();
        }
        public IActionResult Cerez()
        {
            string adi = KurabiyeGetir("ad");
            string yasi = KurabiyeGetir("Yasi");
            return Content($"Adı: {adi} - Yaşı: {yasi}");
        }
    }
}
