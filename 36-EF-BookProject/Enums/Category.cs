using _36_EF_BookProject.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _36_EF_BookProject.Enums
{
    public class Category : BaseEntity
    {
        [Column(TypeName = "nvarchar(50)")]
        public string CategoryName { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string? CategoryDescription { get; set; }

        //Navigation property
        public virtual IList<Book> Book { get; set; }
    }
}
