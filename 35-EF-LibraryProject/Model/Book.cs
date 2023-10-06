using _35_EF_LibraryProject.Model.Abstracr;
using _35_EF_LibraryProject.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _35_EF_LibraryProject.Model
{
    public class Book : BaseModel
    {
        public string BookName { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author{ get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category{ get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public double DisCount { get; set; }
        public StockControl StockControl { get; set; } = StockControl.None;
        public DateTime PublishDate { get; set; }
    }
}
