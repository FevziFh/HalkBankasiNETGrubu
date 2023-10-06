using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _29_EF_RelationshipEFCore.Models
{
    public class ProductDetail : BaseEntity
    {
        //public int ProductDetailId { get; set; }
        public string? Color { get; set; } //Nullable
        public int Height { get; set; }
        public int Width { get; set; }
        public int ProductRefId { get; set; }
        public virtual Product Product { get; set; }
    }
}
