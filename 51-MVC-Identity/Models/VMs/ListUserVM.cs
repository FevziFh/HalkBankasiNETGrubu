using System.ComponentModel.DataAnnotations;

namespace _51_MVC_Identity.Models.VMs
{
    public class ListUserVM
    {
        public string Id { get; set; }
        [Display(Name ="Kullanıcı Adı")]
        public string UserName { get; set; }
        [Display(Name = "Adı")]
        public string FirstName { get; set; }
        [Display(Name = "Soyadı")]
        public string LastName { get; set; }
        [Display(Name = "Mail")]
        public string Email { get; set; }
    }
}
