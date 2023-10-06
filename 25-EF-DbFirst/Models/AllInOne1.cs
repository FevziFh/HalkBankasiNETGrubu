using System;
using System.Collections.Generic;

namespace _25_EF_DbFirst.Models
{
    public partial class AllInOne1
    {
        public string AdSoyad { get; set; } = null!;
        public int OrderId { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
