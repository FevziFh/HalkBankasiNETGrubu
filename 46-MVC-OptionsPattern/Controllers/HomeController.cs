using _46_MVC_OptionsPattern.Classes;
using _46_MVC_OptionsPattern.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace _46_MVC_OptionsPattern.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppSettings _appSettings;

        public HomeController(ILogger<HomeController> logger,IOptions<AppSettings> appSettings)
        {
            //IOptions<>: options sınıfının özelliğine erişim sağlar ve bu örneği. Value özelliği ile döndürür.

            //IOptionsSnapshot<T>: En son yapılandırma ayarlarını dinamik olarak ele alamanıza olanak tanır. Bir Http isteği sırasında güncel yapılandırma ayarlarına ihtiyacımız varsa.
            //IOptionsMonitor<T>: options pattern üzerindaki değişikleri izlemek için kullanılır.
            _logger = logger;
            _appSettings = appSettings.Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Options()
        {
            string key = _appSettings.AppKey;
            string value = _appSettings.AppValue;
            return Content($"Options key: {key} - Value: {value}");

            //Yapılandırma ayarlarını merkezi şekilde yapılmasını sağlar.
            //Daha düzenli kod - kolayca yönetme - sürdürülebilirlik - ortam bağımsızlığı
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