using _29_EF_RelationshipEFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _29_EF_RelationshipEFCore.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer("Server=KDK-403YZ-PC01;Database=RelationDB2;Trusted_Connection=True;");
        }

        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One to Many
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryRefId);

            //One to One
            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductDetail)
                .WithOne(p => p.Product)
                .HasForeignKey<ProductDetail>(p => p.ProductRefId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
