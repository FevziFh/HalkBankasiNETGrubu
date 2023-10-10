using _56_SOLIDPrenciples._05_DependecyInversion.GoodImplementation;

namespace _56_SOLIDPrenciples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //SqlRepository sqlRepository = new SqlRepository();
            NoSqlRepository sqlRepository = new NoSqlRepository();
            SqlService sqlService = new SqlService(sqlRepository);
        }
    }
}