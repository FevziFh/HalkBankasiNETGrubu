using Microsoft.AspNetCore.Identity;

namespace _55_API_JWT_Auhentication.Models
{
    public class AppUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
