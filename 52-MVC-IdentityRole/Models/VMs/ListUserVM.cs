using System.ComponentModel.DataAnnotations;

namespace _52_MVC_IdentityRole.Models.VMs
{
    public class ListUserVM
    {
        public string Id { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }
        [Display(Name = "Adı")]
        public string Email { get; set; }
    }
}
