namespace _50_TASK_Kullanimi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task, asenkron programlamada yapılması gereken işleri temsil eder. Bir işin tamamlanıp tamamlanmadığının durum bilgisini bize söyleyebilir eğer işlem bir sonuç verirse task bize bu sonucu bildirir.

            //Void -> Task GeriDegerDondurenMetot -> Task<TResult

            //Task oluşturmanın 3 yöntemi vardır.
            //1) Task.Factory.StarNew
            //2) Task Instance
            //3) Task.Run Metodu

            #region Task - 1
            //var task = new Task(()=>GetRandomNumber());
            //task.Start();

            //Console.WriteLine("Program başladı");
            //Console.Read();
            #endregion

            #region Task - 2
            //Task.Run(()=>GetRandomNumber() );
            //Console.WriteLine("Program başladı");
            //Console.Read();
            #endregion

            #region Task - 3
            //Task.Factory.StartNew(() => GetRandomNumber());
            //Console.WriteLine("Program Başladı");
            //Console.ReadLine();
            #endregion

            #region Task - 4
            //Task<int> task = Task.Run(() => GetRandomNumber());
            //Console.WriteLine("Rastgele Sayı:" + task.Result);
            //Console.WriteLine("Program başladı");
            //Console.Read();
            #endregion


        }
        static int GetRandomNumber()
        {
            Thread.Sleep(1000);
            int randomNumber = (new Random()).Next(1,100);
            Console.WriteLine($"Rastgele Sayı: {randomNumber}");
            return randomNumber;
        }
    }
}