using System.ComponentModel.DataAnnotations;

namespace _55_API_JWT_Auhentication.Models.DTOs
{
    public class UseForRegistrationDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Required(ErrorMessage = "User is Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
        public string EMail { get; set; }
        public string Phonenumber { get; set; }
    }
}
