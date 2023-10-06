using _35_EF_LibraryProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _35_EF_LibraryProject.DAL
{
    public interface IBookDAL
    {
        void AddBook(Book book);
        void DeleteBook(Book book);
        void UpdateBook(Book book);
        List<BookDTO> GetAllBooksByCategory();
        List<Book> GetBooksByCategory(int categoryId);
        List<Book> GetBooksByAuthor(int authorId);
        List<Book> GetBooksPrice();
        List<Book> GetBooksPublishDate();
        List<Book> GetBooksDicount();
        List<Book> GetBooksStock();
        List<Book> GetBook(string bookname);
        List<Book> GetBooksByTop(int top);
    }
}
