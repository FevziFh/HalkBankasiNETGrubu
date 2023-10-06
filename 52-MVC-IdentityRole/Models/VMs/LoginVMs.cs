using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace _52_MVC_IdentityRole.Models.VMs
{
    public class LoginVMs
    {
        [DisplayName("Kullanıcı Adı")]
        [Required]
        public string Username { get; set; }
        [DisplayName("Kullanıcı Şifre")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
