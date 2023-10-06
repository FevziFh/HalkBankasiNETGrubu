using _42_MVC_Validation.ValidationClasses;
using System.ComponentModel.DataAnnotations;

namespace _42_MVC_Validation.Classes
{
    public class SystemUser
    {
        [Required(ErrorMessage ="Kullanıcı Adı Boş Geçilemez")]
        [StringLength(10,ErrorMessage ="kullanıcı adı en az 3 en çok 10 karakterli olmalı",MinimumLength =2)]
        public string UserName { get; set; }


        [Required(ErrorMessage ="T.C. Kimlik numarası boş geçilemez.")]
        [IdentificationNumberValidation(ErrorMessage ="T.C. Kimlik Uygun formatta giriniz.")]
        public string IdendificationNumber { get; set; }


        [Required(ErrorMessage = "Boş olamaz")]
        [Range(0,100,ErrorMessage = "Puanınız 0 ile 100 arasında olmalıdır.")]
        public int Score { get; set; }


        [Required(ErrorMessage = "Boş olamaz")]
        [EmailAddress(ErrorMessage = "Doğru Formatta Giriniz")]
        public string MailAdress { get; set; }


        [Required(ErrorMessage = "Boş Geçilemez")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Boş Geçilemez")]
        [Compare("Password",ErrorMessage = "Şifreler Eşleşmiyor.")]
        public string PasswordConfirm { get; set; }
    }
}
