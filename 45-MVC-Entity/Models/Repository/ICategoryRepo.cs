namespace _45_MVC_Entity.Models.Repository
{
    public interface ICategoryRepo
    {
        public void AddCategory(Category category);
        public void UpdateCategory(Category category);
        public void DeleteCategory(Category category);
        public Category GetByIdCategory(int id);
        List<Category> GetAllCategories();
    }
}
