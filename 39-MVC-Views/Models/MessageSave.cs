using System.ComponentModel.DataAnnotations;

namespace _39_MVC_Views.Models
{
    public class MessageSave
    {
        [Required(ErrorMessage ="Ad Alanı Boş Geçilemez.")]
        [Display(Name ="Adınızı Giriniz.")]        
        public string FirstName { get; set; }
        [Display(Name = "Soyadınızı Giriniz.")]
        public string LastName { get; set; }
        [Display(Name = "Konuyu Giriniz.")]
        public string Subject { get; set; }
        [Display(Name = "Mesajınızı Giriniz.")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}
