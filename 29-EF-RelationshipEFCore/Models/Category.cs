using _29_EF_RelationshipEFCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _29_EF_RelationshipEFCore.Models
{
    public class Category : BaseEntity
    {
        //public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        //public Status CategoryStatus { get; set; }
        public virtual IList<Product> Products { get; set; }
    }
}
