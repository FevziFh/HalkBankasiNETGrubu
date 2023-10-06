using _29_EF_RelationshipEFCore.Contexts;
using _29_EF_RelationshipEFCore.Enums;
using _29_EF_RelationshipEFCore.Models;
using _29_EF_RelationshipEFCore.Service.Concrete;

namespace _29_EF_RelationshipEFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CategoryService categoryService = new CategoryService(new AppDbContext());

            ////categoryService.Add(new Category() { CategoryName = "Kalem", CategoryStatus = Status.Active });
            //var categoryList = categoryService.GetByDefaults(c => c.CategoryName == "Kalem");

            //foreach (var item in categoryList)
            //{
            //    Console.WriteLine($"Category Id: {item.CategoryId}, Name: {item.CategoryName}");
            //}

            //Category category1 = new Category() { CategoryName = "Kitap", CategoryStatus = Status.Active };

            //BaseService<Category> baseService = new BaseService<Category>(new AppDbContext());
            //baseService.Add(category1);
            using (AppDbContext context = new())
            {
                var list = context.Products.Where(p => p.Id > 0);
                foreach (var item in list)
                {
                    Console.WriteLine("item: " + item.ProductName);
                }
            } 
            
            
            Product product1 = new Product() { Category=new Category() { CategoryName="Kitap" }, ProductName = "Cin Ali Okulda", ProductPrice = 50, ProductStock = 100, Status = Status.Active };

            BaseService<Product> baseService1 = new BaseService<Product>(new AppDbContext());
            baseService1.Add(product1);

            var product2 = baseService1.GetByDefaults(p => p.Status != Status.Passive);

            Console.WriteLine("Başarılı...");
        }
    }
}