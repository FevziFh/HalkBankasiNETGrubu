using _36_EF_BookProject.Context;
using _36_EF_BookProject.DTOs;
using _36_EF_BookProject.Enums;
using _36_EF_BookProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _36_EF_BookProject.Service.Concrete
{
    public class BookService : BaseCRUD<Book>, IBook
    {
        private readonly AppDbContext appDbContext;
        public BookService(AppDbContext appDbContext) : base(appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IList<BookDTO> GetAllBooksWithCategory()
        {
            return appDbContext.Categories.Select(x => new BookDTO { Books = x.Book, CategoryName = x.CategoryName }).OrderBy(x => x.CategoryName).ToList();
        }

        public IList<Book> GetBooksByAuthorName(string authorName)
        {
            return appDbContext.Books.Where(x => x.Author.AuthorFirstName.Contains(authorName)).ToList();
        }

        public IList<Book> GetBooksByCategory(int categoryId)
        {
            return appDbContext.Books.Where(x => x.CategoryId == categoryId).OrderBy(x => x.BookName).ToList();
        }

        public IList<Book> GetBooksByName(string name)
        {
            return appDbContext.Books.Where(X => X.BookName.Contains(name)).OrderByDescending(x => x.CreateDate).ToList();
        }

        public IList<Book> GetBooksByOrderDate()
        {
            return appDbContext.Books.OrderByDescending(x => x.BookPublishDate).ToList();
        }

        public IList<Book> GetBooksByOrderDiscount()
        {
            return appDbContext.Books.Where(x=>x.BookDiscount>0).OrderBy(x => x.BookName).ToList();
        }

        public IList<Book> GetBooksByOrderPrice()
        {
            return appDbContext.Books.OrderByDescending(x => x.BookPrice).ToList();
        }

        public IList<Book> GetBooksByStock()
        {
            return appDbContext.Books.OrderBy(x => x.BookStock).ToList();
        }

        public IList<Book> GetBooksTop10()
        {
            return appDbContext.Books.OrderByDescending(x=>x.Id).Take(10).ToList();
        }
    }
}
