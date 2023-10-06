using _29_EF_RelationshipEFCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _29_EF_RelationshipEFCore.Models
{
    public class Product : BaseEntity
    {
        private int productStock=10;
        private double productPrice;
        public Product()
        {
            //ProductDate = DateTime.Now;
        }
        //public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductStock 
        {
            get { return productStock; }
            set 
            { 
                if(value<0)
                    Console.WriteLine("Stok 0 altına düşemez.");
                else
                    productStock = value;
            }
        }
        public double ProductPrice 
        {
            get { return productPrice; }
            set
            {
                if (value > 0)
                    productPrice = value;
                else
                    Console.WriteLine("Fiyat 0 dan küçük olamaz.");
            }
        }
        //public DateTime ProductDate { get; set; }
        //public Status ProductStatus { get; set; }

        //Navigation Property
        public int CategoryRefId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ProductDetail ProductDetail { get; set; }
    }
}
