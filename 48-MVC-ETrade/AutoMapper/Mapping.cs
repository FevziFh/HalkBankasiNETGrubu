using _48_MVC_ETrade.Models.DTOs;
using _48_MVC_ETrade.Models.Entities;
using _48_MVC_ETrade.Models.Entities.IldenAyrı;
using _48_MVC_ETrade.Models.VMs;
using AutoMapper;

namespace _48_MVC_ETrade.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Category, CategoryListVM>().ReverseMap();
            //CreateMap<CategoryDTO, Category>();
            CreateMap<Category, CategoryDTO>().ForMember(dest => dest.CategoryName, opt => opt.MapFrom(cat => cat.Name)).ReverseMap();

            //CreateMap<Employee, EmployeeDTO>().ForMember(dest => dest.EmployeeFullName, opt => opt.MapFrom(src => src.EmployeeFirstName + " " + src.EmployeeLastName));
            //CreateMap<EmployeeDTO, Employee>().ForMember(dest => dest.EmployeeFirstName + " " + dest.EmployeeLastName, opt => opt.MapFrom(cat => cat.EmployeeFullName));
            CreateMap<Product,ProductCreateVM>().ForMember(dest=>dest.Categories,opt=>opt.Ignore()).ReverseMap();
        }
    }
}
