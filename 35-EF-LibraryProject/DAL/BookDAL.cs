using _35_EF_LibraryProject.Context;
using _35_EF_LibraryProject.Model;
using _35_EF_LibraryProject.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _35_EF_LibraryProject.DAL
{
    public class BookDAL : IBookDAL
    {
        private readonly AppDbContext context;
        public BookDAL(AppDbContext context)
        {
            this.context = context;
        }

        public void AddBook(Book book)
        {
            context.Add(book);
            context.SaveChanges();
        }

        public void DeleteBook(Book book)
        {
            book.DeleteDate = DateTime.Now;
            book.Status = Status.Passive;
            context.Books.Remove(book);
            context.SaveChanges();
        }

        public List<BookDTO> GetAllBooksByCategory()
        {
            return context.Books.Select(x=> new BookDTO{BookName=x.BookName,CategoryName=x.Category.CategoryName}).OrderBy(x=>x.CategoryName).ToList();
        }

        public List<Book> GetBook(string bookname)
        {
            return context.Books.Where(x => x.BookName.Contains(bookname) && x.Stock == 0).ToList();
        }

        public List<Book> GetBooksByAuthor(int authorId)
        {
            return context.Books.Where(x=>x.AuthorId== authorId && x.Stock == 0).ToList();
        }

        public List<Book> GetBooksByCategory(int categoryId)
        {
            return context.Books.Where(x=>x.CategoryId== categoryId && x.Stock == 0).ToList();
        }

        public List<Book> GetBooksByTop(int top)
        {
            List<Book> books= context.Books.Where(x=>x.Stock == 0).OrderByDescending(x=>x.CreateDate).ToList();
            List<Book> booksTopTen = new List<Book>();
            for (int i = 0; i < 10; i++)
            {
                booksTopTen.Add(books[i]);
            }
            return booksTopTen;
        }

        public List<Book> GetBooksDicount()
        {
            return context.Books.Where(x => x.DisCount != 0 && x.DisCount > 0&& x.Stock == 0).OrderBy(x=>x.DisCount).ToList();
        }

        public List<Book> GetBooksPrice()
        {
            return context.Books.OrderBy(x=>x.Price).ToList();
        }

        public List<Book> GetBooksPublishDate()
        {
            return context.Books.OrderBy(x=>x.PublishDate).ToList();
        }

        public List<Book> GetBooksStock()
        {
            return context.Books.Where (x=>x.Stock==0).ToList();
        }

        public void UpdateBook(Book book)
        {
            book.UpdateDate= DateTime.Now;
            book.Status = Status.Modified;
            context.Books.Update(book);
            context.SaveChanges();
        }
    }
}
