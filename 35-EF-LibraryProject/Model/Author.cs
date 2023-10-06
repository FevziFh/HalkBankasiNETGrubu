using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _35_EF_LibraryProject.Model.Abstracr;

namespace _35_EF_LibraryProject.Model
{
    public class Author : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Book> Books { get; set; }

    }
}
