using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31_EF_DataAnnotationAndFluentAPI.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public DateTime AuthorBirtDate { get; set; }
        //[NotMapped]
        public int AuthorAge { get; set; }
        public Deneme MyProperty { get; set; }

        public List<Book> Books { get; set; }
    }

    //[NotMapped]
    public class Deneme
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
