using _48_MVC_ETrade.Models.Entities.Enums;
using System.ComponentModel;

namespace _48_MVC_ETrade.Models.VMs
{
    public class CategoryListVM
    {
        [DisplayName("Kategori Adı")]
        public string Name { get; set; }
        [DisplayName("Eklenme Tarihi")]
        public DateTime? CreateDate { get; set; }
        [DisplayName("Güncelle Tarihi")]
        public DateTime? UpdateDate { get; set; }
        [DisplayName("Silinme Tarihi")]
        public DateTime? DeleteDate { get; set; }
        [DisplayName("Statüsü")]
        public Status Status { get; set; }
    }
}
