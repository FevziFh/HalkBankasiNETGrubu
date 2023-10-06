using _28_EF_CodeFirstModelDbContextDbSet.Context;
using _28_EF_CodeFirstModelDbContextDbSet.Entities;
using Microsoft.EntityFrameworkCore;

namespace _28_EF_CodeFirstModelDbContextDbSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
           // Add();
            Read();
            Console.WriteLine("Hello, World!");
        }

        static void Add()
        {
            //Author author = new Author() { FirstName = "William", LastName = "Shakespeare" };
            //using (var context = new AppDbContext())
            //{
            //    context.Authors.Add(author);
            //    context.SaveChanges();
            //}

            using (var context = new AppDbContext())
            {
                var author = context.Authors.Find(2);

                //Book book = new Book() { Title = "Coding 101", Subject = "C#, SQL, Entity", AuthorId=2 };
                //context.Books.Add(book);
                //context.SaveChanges();

                //Book book = new Book() { Title = "Coding 102", Subject = "C#, SQL, Entity", AuthorId = author.AuthorId };
                //context.Books.Add(book);
                //context.SaveChanges();

                //Book book = new Book() { Title = "Coding 102", Subject = "C#, SQL, Entity", AuthorId = context.Authors.Find(2).AuthorId };
                //context.Books.Add(book);
                //context.SaveChanges();

                //Book book = new Book() { Title = "Coding 103", Subject = "C#, SQL, Entity", Author = author };
                //context.Books.Add(book);
                //context.SaveChanges();

                //Book book = new Book() { Title = "Coding 103", Subject = "C#, SQL, Entity", Author = context.Authors.Find(2) };
                //context.Books.Add(book);
                //context.SaveChanges();

                //Author author1 = new Author() { FirstName = "Ahmet", LastName = "Ümit" };
                //Book book = new Book() { Title = "Sultanı Öldürmek", Subject = "Polisiye", Author = author1 };
                //context.Books.Add(book);
                //context.SaveChanges();

                List<Book> books = new List<Book>()
                {
                    new Book(){ Title="DenemeX1", Subject="123" },
                    new Book(){ Title="DenemeX2", Subject="456"}
                };

                var authorX = new Author() { FirstName = "Fevzi", LastName="Uçar", Books= books };
                context.Add(authorX);
                context.SaveChanges();

                Console.WriteLine("Başarılı");
            }
        }
        static void Read()
        {
            //Read Entity with Single
            //using (var context = new AppDbContext())
            //{
            //    var author1 = context.Authors.Single(a => a.AuthorId == 1);
            //    Console.WriteLine($"Yazar Adı: {author1.FirstName} - {author1.LastName}");
            //}

            //Read Entity with FirstOrDefault
            //using (var context = new AppDbContext())
            //{
            //    var author2 = context.Authors.FirstOrDefault(a => a.FirstName == "William");
            //    Console.WriteLine($"Yazar Adı: {author2.FirstName} - {author2.LastName} ID: {author2.AuthorId}");
            //}

            //Read Entity with Find
            //using (var context = new AppDbContext())
            //{
            //    var author3 = context.Authors.Find(2);
            //    Console.WriteLine($"Yazar Adı: {author3.FirstName} - {author3.LastName} ID: {author3.AuthorId}");
            //}

            //using (var context = new AppDbContext())
            //{
            //    var author4 = context.Authors.ToList();
            //    foreach (var item in author4)
            //    {
            //        Console.WriteLine($"Yazar Adı: {item.FirstName} - {item.LastName} ID: {item.AuthorId}");
            //    }
            //}
            using (var context = new AppDbContext())
            {
                var innerJoin = context.Authors.Join(context.Books,
                    a => a.AuthorId,
                    b => b.AuthorId,
                    (a, b) => new
                    {
                        a.FirstName,
                        a.LastName,
                        b.Title
                    });

                foreach (var item in innerJoin)
                {
                    Console.WriteLine($"Yazar Adı: {item.FirstName} - {item.LastName} Kitap: {item.Title}");
                }
            }

            //Eager Loading (Ileri Yükleme)
            //İlişlili verilere ihtiyaç duyulduğunda yüklenir. Eager loading de ise ilişkili nesnelerin yüklemesi ilk başta yüklü olarak gelir. Bu da gereksiz veya fazladan yükleme yapmamıza sebep olur.

            using (var context = new AppDbContext())
            {
                Console.WriteLine("EagerLoading");
                var BooksWithAuthor = context.Books.Include(b => b.Author).ToList(); //Eager Loading.
                foreach (var book in BooksWithAuthor) 
                {
                    Console.WriteLine($"Kitap Adı: {book.Title} Yazar Adı: {book.Author.FirstName}");
                }
            }

            //Lazy Loading (Tembel Yükleme)
            //İlk yüklemede ana nesne yüklenir. Ihtiyacım olduğu anda ilişkili nesne yüklemesi gerçekleşir.
            using (var context = new AppDbContext())
            {
                Console.WriteLine("LazyLoading");
                var books = context.Books.ToList();
                foreach (var item in books)
                {
                    Console.WriteLine($"Kitap Adı: {item.Title} Yazar Adı: {item.Author.FirstName}");
                }

            }
        }
        static void Update()
        {
            using (var context = new AppDbContext())
            {
                var authorUp = context.Authors.Find(2);
                authorUp.FirstName = "Jane";
                authorUp.LastName = "Amstront";

                //context.Update(authorUp);
                //context.Authors.Update(authorUp);
                context.SaveChanges();
            }
        }
        static void Remove()
        {
            using (var context = new AppDbContext())
            {
                context.Remove(context.Authors.Find(2));
                context.SaveChanges();
            }
        }
    }
}