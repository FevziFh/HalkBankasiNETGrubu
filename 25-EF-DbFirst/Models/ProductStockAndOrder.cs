using System;
using System.Collections.Generic;

namespace _25_EF_DbFirst.Models
{
    public partial class ProductStockAndOrder
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public short? UnitsInStock { get; set; }
        public int? TotalOrder { get; set; }
    }
}
