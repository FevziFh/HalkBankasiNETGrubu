using Microsoft.AspNetCore.Identity;

namespace _52_MVC_IdentityRole.Models.VMs
{
    public class UserRoleVM
    {
        public string Id { get; set; }
        public IList<IdentityRole> Roles { get; set; }
        public string Name { get; set; }
    }
}
