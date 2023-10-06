using _51_MVC_Identity.Context;
using _51_MVC_Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection String Bulunamad?");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connString));

//Add Identity
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    //Password
    options.Password.RequireDigit = false; //en az bir rakam
    options.Password.RequiredLength = 3; //Minimum kaç karakter
    options.Password.RequireLowercase = false; //en az bir küçük harf
    options.Password.RequireUppercase = false; //en az bir büyük harf
    options.Password.RequireNonAlphanumeric = false; //en az bir sembol

    //User
    options.User.RequireUniqueEmail = true; // eposta adresleri benzersiz olmal?
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_";

    //S?ngIn
    options.SignIn.RequireConfirmedEmail = false; //eposta onay? gerekli mi
    options.SignIn.RequireConfirmedPhoneNumber = false; //telefon onay? gerekli mi
    options.SignIn.RequireConfirmedAccount = false;

}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//Kimlik do?rulama
app.UseAuthentication();

//Yetkilendirme i?lemi için
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
