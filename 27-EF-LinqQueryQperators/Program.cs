namespace _27_EF_LinqQueryQperators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Collection - IEnumrable, IQuerable IList, v.b. Kavramlarını araştırınız... 
            //Query Syntax Sorgu, veritabanına sorgu yazmak için T-SQL komutlarına benzer. C# için tanımlanan sorgu komutlarıdır.


            IList<Person> personlist = new List<Person>()
            {
                new Person() { PersonId=1, PersonName="John", PersonAge=18, PersonCity="İstanbul" },
                new Person() { PersonId=2, PersonName="Steve", PersonAge=15, PersonCity="İstanbul"},
                new Person() { PersonId=3, PersonName="Steve", PersonAge=25, PersonCity="İstanbul"},
                new Person() { PersonId=4, PersonName="Ram", PersonAge=20, PersonCity="Ankara"},
                new Person() { PersonId=5, PersonName="Ron", PersonAge=19, PersonCity="İzmir"}
            };

            #region First-FirstOrDefault
            //First, bir koleksiyonun ilk öğesini veya bir koşulu karşılayan ilk öğeyi döndürür.
            //FirstOrDefault, bir koleksiyonun ilk öğesini veya bir koşulu karşılayan ilk öğeyi döndürür. Indeks aralığın dışındaysa default bir değer döndürür.

            var first1 = personlist.First();
            Console.WriteLine(first1.PersonName);

            var first2 = personlist.First(p => p.PersonName == "Steve");
            Console.WriteLine($"First: {first2.PersonName} {first2.PersonId}");

            var first3 = personlist.FirstOrDefault();
            var first4 = personlist.FirstOrDefault(p => p.PersonName == "Fatih");

            //I.Yol
            if (first4==null)
            {
                first4 = new Person() { PersonId = 5, PersonName = "Ron", PersonAge = 19, PersonCity = "İzmir" };
            }


            //II.Yol
            var first5= personlist.FirstOrDefault(p => p.PersonName == "Fatih",new Person() { PersonName="Elif"});
            Console.WriteLine($"First5: {first5.PersonName} {first5.PersonId}");

            //III.Yol
            var first6 = personlist.Where(p => p.PersonName == "Fatih")
                .DefaultIfEmpty(new Person() { })
                .FirstOrDefault(p => p.PersonName == "Fatih");
            Console.WriteLine($"First6: {first5.PersonName} {first5.PersonId}");




            //Console.WriteLine($"First: {first4.PersonName} {first4.PersonId}");
            #endregion

            //Linq Query Syntax: sorgu dizimi from anahtar kelimesiyle başlar ve select anahtar kelimesiyle biter.
            #region Select
            //Select * From Person
            var select1 = from p in personlist select p;
            //Select PersonName, PersonCity From Person
            var selectColumn1 = from p in personlist select new { p.PersonName, p.PersonCity };

            foreach (var person in select1)
            {
                Console.WriteLine($"Query Syntax ID: {person.PersonId} Name: {person.PersonName} Age: {person.PersonAge} City: {person.PersonCity}");
            }

            foreach (var person in selectColumn1)
            {
                Console.WriteLine($"Query Syntax Name: {person.PersonName} City: {person.PersonCity}");
            }

            //Method Syntax
            //SELECT * FROM Person
            var select2 = personlist.ToList();
            foreach (var person in select2)
            {
                Console.WriteLine($"Method Syntax ID: {person.PersonId} Name: {person.PersonName} Age: {person.PersonAge} City: {person.PersonCity}");
            }
            //Select PersonName, PersonCity From Person
            var selectColumn2 = personlist.Select(p => new { p.PersonName, p.PersonCity });
            foreach (var person in selectColumn2)
            {
                Console.WriteLine($"Method Syntax Name: {person.PersonName} City: {person.PersonCity}");
            }

            Console.WriteLine("");
            #endregion

            Console.WriteLine("\n*************************\n");

            #region Where
            //QuerySyntax
            var where1 = from p in personlist where p.PersonAge > 12 && p.PersonAge < 20 select p;
            foreach (var item in where1)
            {
                Console.WriteLine($"Query Syntax Where: Name: {item.PersonName} Age: {item.PersonAge}");
            }

            //MethodSytnax
            var where2 = personlist.Where(p => p.PersonAge > 12 && p.PersonAge < 20);
            foreach (var item in where2)
            {
                Console.WriteLine($"Query Syntax Where: Name: {item.PersonName} Age: {item.PersonAge}");
            }
            #endregion

            Console.WriteLine("\n*************************\n");

            #region OrderBy
            var orderBy1 = from p in personlist orderby p.PersonName select p;
            var orderByDesc1 = from p in personlist orderby p.PersonName descending select p;

            var orderBy2 = personlist.Where(p => p.PersonAge > 12).OrderBy(p => p.PersonName);
            var orderByDesc2 = personlist.OrderByDescending(p => p.PersonName);

            Console.WriteLine("");

            #endregion

            Console.WriteLine("\n*************************\n");

            #region GroupBy
            var groupBy1 = from p in personlist group p by p.PersonAge;

            var groupBy2 = personlist.GroupBy(p => p.PersonAge);
            #endregion

            Console.WriteLine("\n*************************\n");

            #region Any
            //Any, herhangi bir elemanın verilen koşulu sağlayıp sağlamadığını kontrol eder.

            bool any1 = personlist.Any(p => p.PersonCity == "İstanbul");
            Console.WriteLine(any1);

            #endregion

            #region Contains***
            //Contains, koleksiyonda belirtilen bir öğenin var olup olmadığını kontrol eder ve bool döndürür.
            Person person1 = new Person() { PersonId = 3, PersonName = "Steve", PersonAge = 25, PersonCity = "İstanbul" };
            bool contains1 = personlist.Contains(person1);
            Console.WriteLine(contains1);
            #endregion

            #region Average
            //Sayısal verilerin ortalmasını döner.
            var avg = personlist.Average(p => p.PersonAge);
            Console.WriteLine(avg);
            #endregion

            #region Count
            var count = personlist.Count();
            Console.WriteLine(count);
            #endregion

            #region MaxMin
            var max = personlist.Max(p => p.PersonAge);
            var min = personlist.Min(p => p.PersonAge);
            #endregion

            #region Sum
            var sum = personlist.Sum(p => p.PersonId);
            #endregion

            #region Take
            //Take, ilk öğeden başlayarak belirtilen sayıda öğeyi döndürür.

            var take = personlist.Take(4);
            foreach (var item in take)
            {
                Console.WriteLine(item.PersonName);
            }
            Console.WriteLine("\n***************************\n");
            
            //TakeWhile, belirtilen koşul doğru olana kadar öğeleri döndürür.
            var takeWhile = personlist.TakeWhile(p => p.PersonCity == "Istanbul");
            foreach (var item in takeWhile)
            {
                Console.WriteLine($"Person Adi: {item.PersonName} Person City {item.PersonCity}");
            }
            #endregion

            Console.WriteLine("\n***************************\n");

            #region Skip
            //Take, ilk öğeden başlayarak belirtilen sayıda öğeyi atlar ve geri kalanını döndürür.
            var skip = personlist.Skip(2);
            foreach (var item in skip)
            {
                Console.WriteLine(item.PersonName);
            }


            #endregion



            #region Last-LastOrDefault
            //First, bir koleksiyonun ilk öğesini veya bir koşulu karşılayan son öğeyi döndürür.
            //FirstOrDefault, bir koleksiyonun ilk öğesini veya bir koşulu karşılayan son öğeyi döndürür. Indeks aralığın dışındaysa default bir değer döndürür.

            var last1 = personlist.Last();
            Console.WriteLine(last1.PersonName);

            var last2 = personlist.Last(p => p.PersonName == "Steve");
            Console.WriteLine($"Last: {last2.PersonName} {last2.PersonId}");

            var last3 = personlist.LastOrDefault();
            var last4 = personlist.LastOrDefault(p => p.PersonName == "Steve");
            Console.WriteLine($"Last: {last4.PersonName} {last4.PersonId}");
            #endregion

            #region Single-SingleOrDefault
            //Single, Bir koleksiyondaki tek öğeyi veya bir koşulu karşılayan tek öğeyi döndürür. Eğer bulamazsa InvalidOperationException hatası verir.
            //var single1 = personlist.Single();
            var single2 = personlist.Single(p => p.PersonName == "Ram");
            Console.WriteLine($"Single: {single2.PersonName} {single2.PersonId}");
            #endregion

            #region Join
            List<Student> students = new List<Student>()
            {
                new Student() { StudentId=1, StudentName="Elif", StandartId=1 },
                new Student() { StudentId=2, StudentName="Fevzi", StandartId=1 },
                new Student() { StudentId=3, StudentName="Naime", StandartId=1 },
                new Student() { StudentId=4, StudentName="Yasin", StandartId=2 },
                new Student() { StudentId=5, StudentName="Mehmet Ali", StandartId=2}
            };

            List<Standart> standarts = new List<Standart>() 
            { 
                new Standart() { StandartId=1, StandartName="Standart 1" },
                new Standart() { StandartId=2, StandartName="Standart 2" },
                new Standart() { StandartId=3, StandartName="Standart 3" }
            };

            //Method Syntax
            var innerJoin1 = students.Join(//Outher Join
                standarts, //Inner Join
                student => student.StandartId, //outerKeySelector
                standart => standart.StandartId, //InnerKeySelector
                (student, standart) => new 
                { 
                    StudentName = student.StudentName,
                    StandartName = standart.StandartName
                });

            foreach (var item in innerJoin1)
            {
                Console.WriteLine($"Student Name: {item.StudentName}, Standart Name: {item.StandartName}");
            }

            //QuerySyntax
            var innerJoin2 = from student in students //Quther Collection
                             join standart in standarts //Inner Collection
                             on student.StandartId equals standart.StandartId //Key selector
                             select new // Result Selector
                             {
                                 studentName = student.StudentName,
                                 standartName = standart.StandartName
                             };

            foreach (var item in innerJoin2)
            {
                Console.WriteLine($"Student Name: {item.studentName}, Standart Name: {item.standartName}");
            }
            #endregion
        }
    }
}