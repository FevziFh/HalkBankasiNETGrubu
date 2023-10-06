using _28_EF_CodeFirstModelDbContextDbSet.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28_EF_CodeFirstModelDbContextDbSet.Context
{
    //DbContext: Verilerler nesneler olarak etkileşim kurmaktan sorumlu olan birincil sınıftır. System.Data.Entity.DbContext. DbContext API, .NET Framework'ün bir parçası olarak yayınlanmaz. EntityFramework.dll dosyası NuGet Package aracılığıyla gelir.

    public class AppDbContext : DbContext
    {
        //DbSet: model içindeki belirli bir entity için bir koleksiyonu temsil eder. Bir entity karşı veritabanına açılan ağ geçitidir. DbSet<Entity> sınıfları, DbContext'e özellik olarak eklenir ve varsayılan olarak DbSet<Entity> özelliğinin adını alan veritabanı tablolarıyla eşlenir.
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        //SQL Configurasyonlarını yaptığım metot.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer("Server=KDK-403YZ-PC01;Database=Book2;Trusted_Connection=True;");
        }

        //Tablolarımızı Fluent Apı kullanarak özelleştireceğimiz yer.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
