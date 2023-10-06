using Microsoft.AspNetCore.Mvc;

namespace _42_MVC_Routing.Controllers
{
    [Route("products")]
    public class UrunController : Controller
    {
        [Route("product")]
        [Route("products")]
        [Route("product/index")]
        [Route("product/index/{id?}")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("Products/{id}")]
        public IActionResult Details(int id)
        {
            return Content($"Product Id:{id}");
        }
        [Route("Create/{entryID:int}/{slugs}")]
        public IActionResult Create(int entryid,string slugs)
        {
            return Content($"Product Id:{entryid} - {slugs}");
        }
        [Route("Create/{entryID:min(1):range(1,500)}/{slugs}")]
        public IActionResult Create2(int entryid, string slugs)
        {
            return Content($"Product Id:{entryid} - {slugs}");
        }
        [Route("Create/{entryID:regex()}/{slugs}")]
        public IActionResult Create3(int entryid, string slugs)
        {
            return Content($"Product Id:{entryid} - {slugs}");
        }
        //products/Ürün/id?magaza=hepsi&konum=istanbul
        [Route("urun/{id}")]
        public IActionResult GetProduct(int id)
        {
            string gelenDeger1 = Request.Query["magaza"];
            string gelenDeger2 = Request.Query["konum"];
            return Content($"Ürün Id: {id} magaza: {gelenDeger1} konum: {gelenDeger2}");
        }

        //{controller}{action}{area}{page}{id}{slug?}
    }
}
