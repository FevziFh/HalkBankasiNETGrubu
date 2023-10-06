using _30_EF_Inheritance.Context;
using _30_EF_Inheritance.Entities;

namespace _30_EF_Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                context.Employees.Add(new Employee() { AdmissionDate = DateTime.Now, BirthDate = new DateTime(1987, 03, 31), JobDescription = "Engineer", Name = "Beyazıt" });

                context.Customers.Add(new Customer() { BirthDate = new DateTime(1999, 03, 15), LastPurchaseDate = DateTime.Now, Name = "Büşra", TotalVisits = 6 });

                context.SaveChanges();

                var emp = context.Employees.ToList();
                var cus = context.Customers.ToList();

                var people = context.People.ToList();

                people.ForEach(p => 
                { 
                    switch(p) 
                    {
                        case Employee employee:
                            Console.WriteLine($"İşci Adı: {employee.Name}");
                            break;
                        case Customer customer:
                            Console.WriteLine($"Müşteri Adı: {customer.Name}");
                            break;
                        default:
                            break;
                    }
                });



                Console.WriteLine("Başarılı");
            }
        }
    }
}