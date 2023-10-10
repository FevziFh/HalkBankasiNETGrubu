namespace _59_DP_Prototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();
            employee.LoadData();

            Employee employee1 = (Employee)employee.Clone();

            Employee employee2 = (Employee)employee1.Clone();
            List<string> list2=employee2.GetEmpList();
            list2.Add("Irem");

            Console.WriteLine("\nEmployess: ");
            foreach (var item in employee.GetEmpList())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\nEmployess1: ");
            foreach (var item in employee1.GetEmpList())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\nEmployess2: ");
            foreach (var item in employee2.GetEmpList())
            {
                Console.WriteLine(item);
            }
        }
    }
}