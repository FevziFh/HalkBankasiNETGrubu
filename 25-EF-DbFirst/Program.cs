using _25_EF_DbFirst.DbContext;

namespace _25_EF_DbFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NorthwindContext db = new NorthwindContext();
            var employees = db.Employees.ToList();
            foreach (var item in employees)
            {
                Console.WriteLine($"Id: {item.EmployeeId} Name: {item.FirstName} Last Name: {item.LastName}");
            }


        }
    }
}