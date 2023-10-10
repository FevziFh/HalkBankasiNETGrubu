using System.ComponentModel.DataAnnotations;

namespace _55_API_JWT_Auhentication.Models.DTOs
{
    public class UseForAuthenticationDTO
    {
        [Required(ErrorMessage = "User is Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
    }
}
