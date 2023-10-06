using _33_EF_LifeCycleTrackingSeedData.Contexts;
using _33_EF_LifeCycleTrackingSeedData.Models;
using Microsoft.EntityFrameworkCore;

namespace _33_EF_LifeCycleTrackingSeedData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region AsNoTracking
            //Entity Framework'ün Select işlemlerinde döndürdüğü datayı cachleyerek takibe alır. Bunun sebebi datayı güncelleyip SaveChanges metodunu çağırdığumuzda değişikliklerin veritabanına yansımasını sağlamaktır. AsNoTracking() buradaki cash'leme mekanizmasını kaldırarak projenize büyük bir performans katkısında bulunur.

            using (var context = new AppDbContext())
            {
                //context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

                var authorsNoTrack = context.Authors.AsNoTracking().ToList();

                var author = new Author () { FirstName="Ahmet Hamdi", LastName="Tanpınar" };

                authorsNoTrack.Add(author);

                context.SaveChanges();

                foreach (var item in context.Authors.ToList())
                {
                    Console.WriteLine($"First Name: {item.FirstName} Last Name: {item.LastName}");
                }
            }

            Console.WriteLine("As No Trcaking");
            #endregion

            #region LifeCycle
            //EntityLifeCycle, bir entity oluşturulduğu anda, eklendiğinde, değiştirildiğinde, vb. işlemler gerçekleştidiğinde entity state dediğimiz kavramda değişir. Bu duruma life cycle denir. Entity state ise entity durumunu belirten kavramdır. (eklendi mi?, silindi mi?, vb.)
            //System.Data.EntityState'de bulunan bir enum nesnesidir.

            //Entity nesnelerin varoluş durumlarına göre şu state yapılarından birini alır.
            /*
             Added: Entity eklendi (added) olarak işaretlenir.
             Deleted: Entity silindi (deleted) olarak işaretlenir.
             Modified: Entity'de değişikli gerçekleşti.
             Unchanged: Entity'de değişikli olmadı.
             Detached: Entity track edilmedi.
             */

            //Entity State içerik tarafından otomatik olarak belirlenir, ancak geliştirici tarafından manuel olarak da değişitirilebilir.

            using (var context = new AppDbContext())
            {
                //Detached: Henüz context nesnesine set edilmemiş entity.
                var author1 = new Author() { FirstName = "Peyami", LastName = "Sefa" };
                Console.WriteLine("Yazar 1 Durum: " + context.Entry(author1).State); //Durumunu göster (State)

                var getAuthor = context.Authors.ToList();
                foreach (var item in getAuthor) 
                {
                    Console.WriteLine($"First Name: {item.FirstName} Last Name: {item.LastName}");
                }

                //Added:
                context.Entry(author1).State = EntityState.Added;
                Console.WriteLine("Yazar 1 Durum: " + context.Entry(author1).State);
                context.SaveChanges();

                //Unchanged:
                var peyami = context.Authors.FirstOrDefault(a => a.FirstName == "Peyami");
                //Console.WriteLine($"First Name: {peyami.FirstName} Last Name: {peyami.LastName}");
                Console.WriteLine(context.Entry(peyami).State);

                //Modified:
                peyami.FirstName = "PEYAMI";
                peyami.LastName = "SEFA";
                context.Entry(peyami).State = EntityState.Modified;
                Console.WriteLine(context.Entry(peyami).State);
                //Console.WriteLine($"First Name: {peyami.FirstName} Last Name: {peyami.LastName}");

                //Deleted:
                context.Entry(peyami).State = EntityState.Deleted;
                Console.WriteLine(context.Entry(peyami).State);
                context.SaveChanges();

                var getAuthor2 = context.Authors.ToList();
                foreach (var item in getAuthor2)
                {
                    Console.WriteLine($"First Name: {item.FirstName} Last Name: {item.LastName}");
                }
            }
            #endregion
        }
    }
}