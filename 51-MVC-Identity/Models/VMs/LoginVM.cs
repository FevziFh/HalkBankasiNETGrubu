using Microsoft.AspNetCore.Cors;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _51_MVC_Identity.Models.VMs
{
    public class LoginVM
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
