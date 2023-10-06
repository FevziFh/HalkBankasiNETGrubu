using System;
using System.Collections.Generic;

namespace _26_EF_DbFirstRehber.Models
{
    public partial class TelefonRehberi
    {
        public int KisiId { get; set; }
        public string? KisiAdi { get; set; }
        public string? KisiSoyadi { get; set; }
        public string? KisiTelefon { get; set; }
    }
}
