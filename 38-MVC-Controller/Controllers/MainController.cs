using _38_MVC_Controller.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace _38_MVC_Controller.Controllers
{
    public class MainController : Controller
    {
        //Kullanıcı istekleri alır, işler, model verileriyle etkileşime girer ve sonuç olarak view oluşturur.
        /*
            1-Kullanıcı isteklerini İşleme
            2-İş Mantığı İşleme
            3-Model ile Etkileşim
            4-View ile Etkileşim
            5-Üretim
         */
        //Metot Action, HTTp isteklerini isteklerini işlemek için kullanılan metotlardır. HTTP GET ve POST isteklerini karşılar. 
        //-Parametre alabilirler.
        //-ActionResult döndürür.


        //HTTP isteklerini karşılamak için Action Verb dediğimiz yapıları kullanırız.
        //Get-Post-Put-Delete-Patch-Head-Options 
        [HttpGet]
        public IActionResult Index()
        {
            //return View();
            //return PartialView("../Home/Index");
            //return Content("Hoşgeldiniz");
            //return Redirect("../Home/Index");
            //return RedirectPermanent("../Home/Index");

            //var data = new { Name = "Fatih", Age = 36 };
            //return Json(data);

            //byte[] fileContents = GetFileContents();
            //return File(fileContents, "aplication/pdf", "debene.pdf");
            //if (true)
            //{
            //    return View();
            //}
            //else
            //    return BadRequest();

            var data = new { Message = "işlem Başarılı" };
            return Json(data);
        }
        [HttpPost]
        public IActionResult Index(Product product)
        {
            return Content("Hoşgeldiniz");
        }
        //[HttpGet]
        //[HttpPost]
        //public IActionResult Index2()
        //{
        //    return Content("Hoşgeldiniz");
        //}

    }
}
