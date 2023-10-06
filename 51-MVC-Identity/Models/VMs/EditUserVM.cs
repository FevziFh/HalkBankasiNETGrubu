using System.ComponentModel.DataAnnotations;

namespace _51_MVC_Identity.Models.VMs
{
    public class EditUserVM
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "Kullanıcı Adi:")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Adi:")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Soyadi:")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Email:")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Telefon:")]
        [Phone]
        public string Phone { get; set; }
    }
}
