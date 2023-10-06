using _48_MVC_ETrade.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace _48_MVC_ETrade.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
