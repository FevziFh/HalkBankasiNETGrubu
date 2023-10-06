using _53_API_Introduction.Models;
using Microsoft.AspNetCore.Mvc;

namespace _53_API_Introduction.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class HomeController : Controller
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

        //EndPoints
        [HttpGet]
        public List<Book> Books()
        {
            var booklist=books.OrderBy(b=>b.Id).ToList(); 
            return booklist;
        }
    }
}
