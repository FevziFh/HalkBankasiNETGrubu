internal class Program
{
    private static void Main(string[] args)
    {
        //Task Bekletme (Wait, WaitAll, WaitAny)
        /*
         -Wait: ilgili task tamamlanması bitmeden bir sonraki kod satırı çalıştırılmaz.
         -WaitAll: Parametredeki tüm taskların tamamlanması bitmeden bir sonraki kod çalıştırılmaz.
         -WaitAny: Parametredeki tasklardan herhangi biri tamamlanmadan bir sonraki kod satırı çalıştırılır.
         */
        //StartSchool().Wait();

        Task.WaitAny(StartSchool(), TeachClass12());
        //TeachClass12();
        TeachClass11();

        Console.Read();

        //Async (içersinde async işlem yapıcak metodu temsil eder.),Await (async olarak işaretlenen metotde asenkron çalışacak komutları temsil eder), Taskk (asenkron metodu temsil eder.)
    }
    public static async Task StartSchool()
    {
        await Task.Delay(8000);
        await Console.Out.WriteLineAsync("Okul başladı");
    }
    public static async Task TeachClass12()
    {
        await Task.Delay(3000);
        await Console.Out.WriteLineAsync("12.sınıflar okula başladı");
    }
    public static async Task TeachClass11()
    {
        await Task.Delay(2000);
        await Console.Out.WriteLineAsync("11.sınıflar okula başladı");
    }
    #region Senkron Programlama
    //public static void StartSchool()
    //{
    //    Thread.Sleep(8000);
    //    Console.WriteLine("Okul Başladı");
    //}
    //public static void TeachClass12()
    //{
    //    Thread.Sleep(3000);
    //    Console.WriteLine("12.Sınıf eğitime başladı");
    //}
    //public static void TeachClass11() 
    //{
    //    Thread.Sleep(2000);
    //    Console.WriteLine("11.Sınıf eğitime başladı");
    //}
    #endregion
}