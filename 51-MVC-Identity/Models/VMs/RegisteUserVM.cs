using System.ComponentModel.DataAnnotations;

namespace _51_MVC_Identity.Models.VMs
{
    public class RegisteUserVM
    {
        [Required]
        [Display(Name ="Kullanıcı Adi:")]
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
        [Required]
        [Display(Name = "Şifre:")]
        [DataType(DataType.Password)]
        [StringLength(10,ErrorMessage ="Maksimum 10 minimum 3 olamlı",MinimumLength = 3)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "TekrarŞifre:")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Girilen şifreler uyumlu olmalıdır.")]
        [StringLength(10, ErrorMessage = "Maksimum 10 minimum 3 olamlı", MinimumLength = 3)]
        public string ConfirmPassword { get; set; }
    }
}
