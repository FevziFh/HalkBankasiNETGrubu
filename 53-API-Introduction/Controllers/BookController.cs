using _53_API_Introduction.Models;
using Microsoft.AspNetCore.Mvc;

namespace _53_API_Introduction.Controllers
{
    [ApiController]
    [Route("api/[controller]s/[action]")]//api/books/books
    public class BookController : Controller
    {
        private static IList<Book> books = new List<Book>()
        {
            new Book(){Id=1, Title="Kitap-1", GenreId=1,PageCount=200,PublishDate=new DateTime(1994,10,15)},
            new Book(){Id=2, Title="Kitap-2", GenreId=1,PageCount=200,PublishDate=new DateTime(1995,10,15)},
            new Book(){Id=3, Title="Kitap-3", GenreId=1,PageCount=200,PublishDate=new DateTime(1992,10,15)},
            new Book(){Id=4, Title="Kitap-4", GenreId=2,PageCount=200,PublishDate=new DateTime(1999,10,15)},
            new Book(){Id=5, Title="Kitap-5", GenreId=1,PageCount=200,PublishDate=new DateTime(1988,10,15)},
            new Book(){Id=6, Title="Kitap-6", GenreId=2,PageCount=200,PublishDate=new DateTime(1990,10,15)},
            new Book(){Id=7, Title="Kitap-7", GenreId=2,PageCount=200,PublishDate=new DateTime(1996,12,15)},
            new Book(){Id=8, Title="Kitap-8", GenreId=1,PageCount=200,PublishDate=new DateTime(1987,10,15)},
            new Book(){Id=9, Title="Kitap-9", GenreId=2,PageCount=200,PublishDate=new DateTime(1998,10,15)},
            new Book(){Id=10, Title="Kitap-10", GenreId=2,PageCount=200,PublishDate=new DateTime(1991,10,15)}
        };

        //api metotları
        //-Void, Primitive tip veya complex tip
        //-HttpResponseMessage
        //-IActionResult
        //-EndPoints
        [HttpGet]
        public List<Book> Books()
        {
            var booklist = books.OrderBy(b => b.Id).ToList();
            return booklist;
        }
        //[HttpGet("id")]
        //public Book BooksById(int id)
        //{
        //    var book = books.SingleOrDefault(x => x.Id == id);
        //    return book;
        //}

        [HttpGet("Id")]
        public Book BookById([FromQuery] string id)
        {
            var book = books.SingleOrDefault(x => x.Id == int.Parse(id));
            return book;
        }
        [HttpPost]
        public IActionResult AddBook([FromBody] Book newbook)
        {
            var book = books.SingleOrDefault(x=>x.Title==newbook.Title);
            if (book is not null)
            {
                return BadRequest();
            }
            else
            {
                books.Add(newbook);
                return Ok();
            }                
        }
        [HttpPut("ID")]
        public IActionResult UpdateBook(int id, [FromBody] Book updateBook)
        {
            var book = books.SingleOrDefault(x=>x.Id == id);
            if (book is not null)
            {
                return BadRequest();
            }
            else
            {
                book.GenreId = updateBook.GenreId != default ? updateBook.GenreId : book.GenreId;
                book.PageCount = updateBook.PageCount != default ? updateBook.PageCount : book.PageCount;
                book.PublishDate = updateBook.PublishDate != default ? updateBook.PublishDate : book.PublishDate;
                book.Title = updateBook.Title != "string" ? updateBook.Title : book.Title;
                return Ok();
            }
        }
        [HttpDelete("ID")]
        public void DeleteBook(int id)
        {
            var book = books.SingleOrDefault(c=> c.Id == id);
            books.Remove(book);
        }
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var book = books.SingleOrDefault(x => x.Id == id);
            if (book is null)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            }
            else 
                return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
        }
    }
}
