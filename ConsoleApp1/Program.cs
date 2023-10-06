using Movie.DATA.Concrete;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            FilmCategory filmCategory = new FilmCategory();
            filmCategory.CategoryName = "Fıstıkçı Şahap";
            Console.WriteLine(filmCategory.CategoryURL);

            Console.WriteLine("");

        }
    }
}