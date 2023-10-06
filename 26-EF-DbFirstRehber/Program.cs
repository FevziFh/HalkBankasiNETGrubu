using _26_EF_DbFirstRehber.AppDbContext;
using _26_EF_DbFirstRehber.Models;

namespace _26_EF_DbFirstRehber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Add();
            Select();
            Console.WriteLine("İşlem Tamamlandı...");
        }
        public static void Select()
        { 
            using(RehberContext db = new RehberContext()) 
            {
                var rehber = db.TelefonRehberis.ToList();
                foreach (var item in rehber)
                {
                    Console.WriteLine($"Kişi Adi: {item.KisiAdi} Kişi Soyadı: {item.KisiSoyadi} Kişi Telefon: {item.KisiTelefon}");
                }
            }
        }

        public static void Add()
        {
            using (RehberContext db = new RehberContext())
            {
                TelefonRehberi rehber1 = new TelefonRehberi();
                rehber1.KisiAdi = "Fatih";
                rehber1.KisiSoyadi = "Alkan";
                rehber1.KisiTelefon = "5547746909";

                db.TelefonRehberis.Add(rehber1);

                TelefonRehberi rehber2 = new TelefonRehberi();
                rehber1.KisiAdi = "Fezi";
                rehber1.KisiSoyadi = "Alkan";
                rehber1.KisiTelefon = "5547746909";

                db.TelefonRehberis.Add(rehber2);

                TelefonRehberi rehber3 = new TelefonRehberi();
                rehber1.KisiAdi = "Elif";
                rehber1.KisiSoyadi = "Alkan";
                rehber1.KisiTelefon = "5547746909";

                db.TelefonRehberis.Add(rehber3);

                db.SaveChanges();
            }
        }
    }
}