using _48_MVC_ETrade.Models.Entities;
using _48_MVC_ETrade.Models.VMs;
using _48_MVC_ETrade.Repositories.Abstracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace _48_MVC_ETrade.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepo _repo;
        private readonly ICategoryRepo _categoryRepo;
        private readonly IMapper _mapper;
        public ProductController(IProductRepo repo, IMapper mapper,ICategoryRepo categoryRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _categoryRepo = categoryRepo;
        }
        public IActionResult Index()
        {
            var product=_repo.GetAllProduct().ToList();
            return View(product);
        }
        public IActionResult Create()
        {
            ProductCreateVM productCreateVM = new ProductCreateVM();
            productCreateVM.Categories = _categoryRepo.GetAllCategory().ToList();
            return View(productCreateVM);
        }
        [HttpPost]
        public IActionResult Create(ProductCreateVM productCreateVM)
        {
            //if (ModelState.IsValid)
            //{
                var product=_mapper.Map<Product>(productCreateVM);
                _repo.AddProduct(product);
                return RedirectToAction("Index");
            //}
            //return View(productCreateVM);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _repo.GetByProductId(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product,IFormFile file)
        {
            string imgName = string.Empty;
            if(file != null)
            {
                string imgExtension = Path.GetExtension(file.FileName);
                imgName = Guid.NewGuid() + imgExtension;

                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/img/{imgName}");
                using var stream = new FileStream(path, FileMode.Create);
                file.CopyTo(stream);
            }

            product.ProductImage = imgName;
            _repo.UpdateProduct(product);
            return RedirectToAction("Index");
        }
    }
}
