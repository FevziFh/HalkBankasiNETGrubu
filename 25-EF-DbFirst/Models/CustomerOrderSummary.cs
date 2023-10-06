using System;
using System.Collections.Generic;

namespace _25_EF_DbFirst.Models
{
    public partial class CustomerOrderSummary
    {
        public string CustomerId { get; set; } = null!;
        public string? ContactName { get; set; }
        public int? OrderCount { get; set; }
    }
}
