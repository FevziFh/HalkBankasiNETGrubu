using _48_MVC_ETrade.Context;
using _48_MVC_ETrade.Models.Entities;
using _48_MVC_ETrade.Models.Entities.Enums;
using _48_MVC_ETrade.Repositories.Abstracts;

namespace _48_MVC_ETrade.Repositories.Concretes
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDbContext _context;

        public ProductRepo(AppDbContext context)
        {
            _context = context;
        }
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            product.DeleteDate = DateTime.Now;
            product.Status = Status.Passive;
            _context.SaveChanges();
        }

        public IList<Product> GetAllProduct()
        {
            return _context.Products.Where(p => p.Status != Status.Passive).ToList();
        }

        public Product GetByProductId(int id)
        {
            return _context.Products.Find(id);        
        }

        public void UpdateProduct(Product product)
        {
            product.UpdateDate = DateTime.Now;
            product.Status = Status.Modified;
            _context.Update(product);
            _context.SaveChanges();
        }
    }
}
