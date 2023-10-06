using _48_MVC_ETrade.Models.Entities;

namespace _48_MVC_ETrade.Repositories.Abstracts
{
    public interface IProductRepo
    {
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        Product GetByProductId(int id);
        IList<Product> GetAllProduct();
    }
}
