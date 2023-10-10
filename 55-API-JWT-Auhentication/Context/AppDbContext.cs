using _55_API_JWT_Auhentication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _55_API_JWT_Auhentication.Context
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                    new IdentityRole()
                    {
                        Name = "User",
                        NormalizedName = "NAME",
                    },
                    new IdentityRole()
                    {
                        Name = "Admin",
                        NormalizedName = "ADMIN",
                    }
                );
            base.OnModelCreating(builder);
        }
    }
}
