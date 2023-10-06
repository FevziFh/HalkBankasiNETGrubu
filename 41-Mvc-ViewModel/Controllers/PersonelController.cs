using _41_Mvc_ViewModel.Models;
using _41_Mvc_ViewModel.Models.Enums;
using _41_Mvc_ViewModel.Models.VMs;
using Microsoft.AspNetCore.Mvc;

namespace _41_Mvc_ViewModel.Controllers
{
    public class PersonelController : Controller
    {
        List<Department> departments = new List<Department>()
        {
            new Department()
            {
                Id = 1,Name="Yazılım"
            },
            new Department()
            {
                Id = 2,Name="Muasebe"
            },
            new Department()
            {
                Id = 3,Name="IT"
            },
            new Department()
            {
                Id = 4,Name="IK"
            }
        };

        List<Personel> personels = new List<Personel>()
        {
            new Personel() {
                Id=1, 
                Name="Fatih",
                BirthDate=new DateTime(1987,03,31), 
                WorkingType=WorkingType.FullTime,
            },
            new Personel() {
                Id=2,
                Name="Mahmut",
                BirthDate=new DateTime(1987,03,31),
                WorkingType=WorkingType.PartTime,
            },
            new Personel() {
                Id=3,
                Name="Sultan",
                BirthDate=new DateTime(1987,03,31),
                WorkingType=WorkingType.ProjectBased,
            },
            new Personel() {
                Id=4,
                Name="Kadir",
                BirthDate=new DateTime(1987,03,31),
                WorkingType=WorkingType.Freelance,
            },
        };

        public IActionResult Index()
        {
            return View(personels);
        }
        [HttpGet]
        public IActionResult Create()
        {
            CreateVM createVM = new CreateVM();
            createVM.Personel = new Personel();
            createVM.Departments = departments;
            return View(createVM);
        }
        [HttpPost]
        public IActionResult Create(CreateVM createVM)
        {
            personels.Add(createVM.Personel);
            return View("Index",personels);
        }
    }
}
