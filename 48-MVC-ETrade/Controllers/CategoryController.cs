using _48_MVC_ETrade.Models.DTOs;
using _48_MVC_ETrade.Models.Entities;
using _48_MVC_ETrade.Models.Entities.IldenAyrı;
using _48_MVC_ETrade.Models.VMs;
using _48_MVC_ETrade.Repositories.Abstracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace _48_MVC_ETrade.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepo _repo;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepo repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;

            //EmployeeDTO employee = new EmployeeDTO() { EmployeeId = 1, EmployeeFullName = "Fevzi Deneme", Deparment = "MIT" };
            //var empDTO = mapper.Map<EmployeeDTO, Employee>(employee);
            //string id = empDTO.EmployeeId.ToString();
            //string name = empDTO.EmployeeFirstName;
            //string name2=empDTO.EmployeeLastName;
            //string department = empDTO.Deparment;
        }
        public IActionResult Index()
        {
            //var cat1 = _mapper.Map<CategoryListVM>(_repo.GetAllCategory());
            var cats = _repo.GetAllCategory().Select(c => _mapper.Map<CategoryListVM>(c));
            return View(cats);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<CategoryDTO, Category>(categoryDTO);
                _repo.AddCategory(category);
                return RedirectToAction("Index");
            }
            else
            {
                return View(categoryDTO);
            }
        }
        [HttpGet]
        public IActionResult Update() 
        {
            return View();
        }
    }
}
