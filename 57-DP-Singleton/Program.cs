namespace _57_DP_Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //EagerSingleton eagerSingleton = new EagerSingleton();
            EagerSingleton.GetInstance();

            SampleSingleton sampleSingleton = SampleSingleton.CreateSampleSingleton();

            sampleSingleton.Data = "First Instance";

            SampleSingleton sampleSingleton2 = SampleSingleton.CreateSampleSingleton();
            SampleSingleton sampleSingleton3 = SampleSingleton.CreateSampleSingleton();

            Console.WriteLine("Nesne-1 : " + sampleSingleton.Data);
            Console.WriteLine("Nesne-2 : " + sampleSingleton2.Data);
            Console.WriteLine("Nesne-3 : " + sampleSingleton3.Data);
            if (sampleSingleton == sampleSingleton2 && sampleSingleton == sampleSingleton3 && sampleSingleton2 == sampleSingleton3) 
            {
                Console.WriteLine("same instance");
            }
        }
    }
}