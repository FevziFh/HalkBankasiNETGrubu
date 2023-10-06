using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31_EF_DataAnnotationAndFluentAPI.Models
{
    //[Table("TblBook")]
    public class Book
    {
        //[Key]
        public int BookId { get; set; }

        //[Required]
        //[MaxLength(50)]
        //[StringLength(50)] -- Nesne tarafında kontrol gerçekleştirir.
        public string BookName { get; set; }

        //[Column("ClmBookSubject", Order = 2, TypeName = "nvarchar(50)")]
        public string BookSubject { get; set; }

        //[ForeignKey("Author")]
        public int AuthorFKId { get; set; }

        //Yani, bir kullanıcı bir veriyi alırken(okurken) başka bir kullanıcı tarafından bu veri değiştirildiyse veya kaydedildiyse, veriyi kaydetmeye çalışan kullanıcıya bir hata bildirilir.

        //Genellikle eş zamanlı güncellemelerin kontrolü için kullanılır.
        //[ConcurrencyCheck]
        public int BookStock { get; set; }

        public Author Author { get; set; }
    }
}
