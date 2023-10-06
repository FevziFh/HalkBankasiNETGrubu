using _36_EF_BookProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _36_EF_BookProject.Enums
{
    public class Book : BaseEntity
    {
        private int _bookStock;
        private bool _bookStockStatus;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string BookName { get; set; }
        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public double BookPrice { get; set; }
        [Required]
        public int BookStock {
            get { return _bookStock; }
            set
            {
                if (_bookStock >= 0) 
                {
                    _bookStock = value;
                }
                else
                    throw new Exception("Stok 0 altında olamaz.");
            }
        }
        [Column(TypeName = "decimal(8,2)")]
        public double? BookDiscount { get; set; }
        public bool BookStockStatus {
            get { return _bookStockStatus; }
            set
            {
                if (BookStock > 0) 
                {
                    _bookStockStatus = true;
                }
                else
                    _bookStockStatus = false;
            }
        } 
        [Column(TypeName = "date")]
        public DateTime? BookPublishDate { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }

        //Navigation Property
        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }
    }
}
