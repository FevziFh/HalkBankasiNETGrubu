using _35_EF_LibraryProject.Context;
using _35_EF_LibraryProject.DAL;
using _35_EF_LibraryProject.Model;

namespace _35_EF_LibraryProject
{
    internal class Program
    {
        static BookDAL bookDAL;
        static AuthorDAL authorDAL;
        static CategoryDAL categoryDAL;
        static AppDbContext context;

        static void Main(string[] args)
        {
            context = new();
            bookDAL = new(context);
            authorDAL = new(context);
            categoryDAL = new(context);

            //authorDAL.AddAuthor(new Author
            //{
            //    Name = "Dram",
            //    Description = "asdsadas"
            //});

            //categoryDAL.AddCategory(new Category
            //{
            //    CategoryName = "test"
            //});

            //bookDAL.AddBook(
            //    new Book
            //    {
            //        BookName = "sadsadsd3326",
            //        AuthorId = 4,
            //        CategoryId = 2,
            //        Price = 60,
            //        Stock = 10,
            //        DisCount = 15,
            //        PublishDate = DateTime.Now
            //    }
            //    );
            var books = bookDAL.GetAllBooksByCategory();
            foreach (var item in books)
            {
                Console.WriteLine($"Kategori: {item.CategoryName}, Kitap: {item.BookName}");
            }

            Console.WriteLine("Hello, World!");
        }
    }
}