using _48_MVC_ETrade.Context;
using _48_MVC_ETrade.Models.Entities;
using _48_MVC_ETrade.Models.Entities.Enums;
using _48_MVC_ETrade.Repositories.Abstracts;

namespace _48_MVC_ETrade.Repositories.Concretes
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly AppDbContext _context;

        public CategoryRepo(AppDbContext context)
        {
            _context = context;
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            category.DeleteDate= DateTime.Now;
            category.Status = Status.Passive;
            _context.SaveChanges();
        }

        public IList<Category> GetAllCategory()
        {
            return _context.Categories.Where(p => p.Status != Status.Passive).ToList();
        }

        public Category GetByCategoryId(int id)
        {
            return _context.Categories.Find(id);
        }

        public void UpdateCategory(Category category)
        {
            category.UpdateDate = DateTime.Now;
            category.Status = Status.Modified;
            _context.SaveChanges();
        }
    }
}
