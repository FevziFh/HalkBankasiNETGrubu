using _36_EF_BookProject.DTOs;
using _36_EF_BookProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _36_EF_BookProject.Service.Interface
{
    public interface IBook
    {
        IList<BookDTO> GetAllBooksWithCategory();
        IList<Book> GetBooksByCategory(int categoryId);
        IList<Book> GetBooksByAuthorName(string authorName);
        IList<Book> GetBooksByOrderPrice();
        IList<Book> GetBooksByOrderDate();
        IList<Book> GetBooksByOrderDiscount();
        IList<Book> GetBooksByStock();
        IList<Book> GetBooksByName(string name);
        IList<Book> GetBooksTop10();
    }
}
