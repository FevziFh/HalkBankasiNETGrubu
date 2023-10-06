using _30_EF_Inheritance.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30_EF_Inheritance.Context
{
    public class AppDbContext : DbContext
    {
        #region TPH
        //Bu yaklaşım tüm kalıtım yapısını temsil etmek için veritabanında tek bir tablo oluşturacaktır.
        public DbSet<BasePerson> People { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }

        //Avantajları
        //Join işlemi gerekmediğinen daha iyi performans sağlar, ancak bir çok sutun için veritabanı birçok disk belleği işlemi gerçekleştirir.
        //Kullanım ve oluşturması kolay.
        //Dezavantajları
        //3rd Normal Formu Ihlal Eder.
        #endregion

        #region TPT
        //Bu yaklaşım, tüm kalıtım yapısını temsil etmek için veritabanında (n) adet (n-subclass) tablo oluşturacaktır.
        //public DbSet<Employee> Employees { get; set; }
        //public DbSet<Customer> Customers { get; set; }

        //Avantajları
        //Normalize Tablolar
        //Koloy Kolun ekleme
        //az sayıda null kolon
        #endregion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=KDK-403YZ-PC01;Database=InheritanceDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
