

using System.ComponentModel.DataAnnotations;

namespace _41_Mvc_ViewModel.Models
{
    public class Futbolcu
    {
        [Required(ErrorMessage = "Bu Alan boş geçilemez")]
        public int Id { get; set; }
        [Required(ErrorMessage ="Bu Alan boş geçilemez")]
        public string Adi { get; set; }
        [Required(ErrorMessage = "Bu Alan boş geçilemez")]
        public int Yas { get; set; }
        public int MevkiId { get; set; }
        public int TakimId { get; set; }
    }
}
