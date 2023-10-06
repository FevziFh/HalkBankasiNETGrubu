using _31_EF_DataAnnotationAndFluentAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31_EF_DataAnnotationAndFluentAPI.Contexts
{
    public class AppDbContext : DbContext
    {

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=KDK-403YZ-PC01;Database=Deneme;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Column
            modelBuilder.Entity<Book>()
                .Property(p => p.BookName)
                .HasColumnName("ClmBookName")
                .HasColumnOrder(2)
                .HasColumnType("nvarchar(50)")
                .IsRequired(required: false);

            //ConcurrencyChek
            modelBuilder.Entity<Author>().Property(a => a.AuthorName).IsConcurrencyToken();

            //Key
            modelBuilder.Entity<Book>().HasKey(b => b.BookId);

            //CompositeKey
            //modelBuilder.Entity<Book>().HasKey(o => new { o.BookId, o.Author.AuthorId });

            //MaxLength
            modelBuilder.Entity<Book>().Property(b => b.BookSubject).HasMaxLength(128);

            //Table
            modelBuilder.Entity<Author>().ToTable("TblYazar");

            //NotMappet - Class
            modelBuilder.Ignore<Deneme>();

            //NotMappet - Property
            modelBuilder.Entity<Author>().Ignore(a => a.AuthorAge);

            //ForegeinKey
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorFKId);
        }
    }
}
