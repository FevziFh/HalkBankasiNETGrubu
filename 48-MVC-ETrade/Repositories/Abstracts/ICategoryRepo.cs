using _48_MVC_ETrade.Models.Entities;

namespace _48_MVC_ETrade.Repositories.Abstracts
{
    public interface ICategoryRepo
    {
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
        Category GetByCategoryId(int id);
        IList<Category> GetAllCategory();
    }
}
