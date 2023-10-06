using _41_Mvc_ViewModel.Models;
using _41_Mvc_ViewModel.Models.Data;
using _41_Mvc_ViewModel.Models.VMs;
using Microsoft.AspNetCore.Mvc;

namespace _41_Mvc_ViewModel.Controllers
{
    public class PlayerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddFutbolcu()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddFutbolcu(Futbolcu futbolcu)
        {
            Data.futbolcuList.Add(futbolcu);
            return View();
        }
    }
}
