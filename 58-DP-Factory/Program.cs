namespace _58_DP_Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var gamePC = FactoryComputer.FactoryMetod(ModelPC.GamePC, "16", "I7", "1TB");

            var devPC = FactoryComputer.FactoryMetod(ModelPC.DeveloperPC, "32", "I7", "500GB");
            var offPC = FactoryComputer.FactoryMetod(ModelPC.OfficePC, "8", "I5", "500GB");
            Console.WriteLine("Game PC: \n" + gamePC.ToString());
            Console.WriteLine("Develop PC: \n" + devPC.ToString());
            Console.WriteLine("Office PC: \n" + offPC.ToString());
        }
    }
}