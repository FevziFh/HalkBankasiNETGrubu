using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28_EF_CodeFirstModelDbContextDbSet.Entities
{
    public class Book
    {
        public int BookId { get; set; } //Primary Key
        public string Title { get; set; }
        public string Subject { get; set; }
        public int AuthorId { get; set; } //Foregein Key

        //Navigation Property
        public virtual Author Author { get; set; }
    }
}
