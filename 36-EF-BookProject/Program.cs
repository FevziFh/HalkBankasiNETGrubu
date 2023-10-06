using _36_EF_BookProject.Context;
using _36_EF_BookProject.Enums;
using _36_EF_BookProject.Service.Concrete;

namespace _36_EF_BookProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDbContext appDbContext = new();
            BookService bookService = new(appDbContext);

            //bookService.Add(new Book
            //{
            //    BookName = "Roman-4",
            //    BookPrice = 16,
            //    BookDiscount = 0.30,
            //    BookPublishDate = new DateTime(1985, 5, 31),
            //    AuthorId = 2,
            //    BookStock = 10,
            //    CategoryId = 6
            //});

            //Kategorili Şekilde Getir
            var books1 = bookService.GetAllBooksWithCategory();
            foreach (var item in books1)
            {
                Console.WriteLine(item.CategoryName);
                foreach (var book in item.Books)
                {
                    Console.WriteLine("\t"+ book.BookName);
                }
            }

            //var books2 = bookService.GetBooksByAuthorName("fa");
            var books2 = bookService.GetBooksByCategory(5);
            foreach (var item in books2)
            {
                Console.WriteLine($"Kitap Adı: {item.BookName} - Yazar Adı: {item.Category.CategoryName}");
            }
            Console.WriteLine("Başarılı");
        }
    }
}