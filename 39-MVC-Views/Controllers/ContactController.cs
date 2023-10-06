using _39_MVC_Views.Models;
using Microsoft.AspNetCore.Mvc;

namespace _39_MVC_Views.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetMessage(MessageSave message)
        {
            if (message is not  null)
            {
                ViewBag.Message = "İşlem Başarılı";
                return View(message);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public IActionResult MesajGonder()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MesajGonder(MessageSave messageSave, string firstName, string lastName)
        {
            return View();
        }
    }
}
