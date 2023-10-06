using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31_EF_DataAnnotationAndFluentAPI.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)] //Hiçbir Otomatik oluşturma veya değer belirleme yapılmasını istemiyorsanız.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Bir kolonun identity olarak yönetilmesini sağlar.
        public string Email { get; set; }
        public string Subject { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)] //Bi kolonun değerlerinin bir hesapalama veya ifade sonucunda otomatik olarak belirlenmesi sağlar.
        public DateTime LastAccesed { get; set; }
    }
}
