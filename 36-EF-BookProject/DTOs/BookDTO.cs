using _36_EF_BookProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _36_EF_BookProject.DTOs
{
    public class BookDTO
    {
        public IList<Book> Books { get; set; }
        public string CategoryName { get; set; }
    }
}
