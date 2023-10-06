using _47_MVC_DependencyInjection.Classes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddTransient
//--Her istek(request) için yeni bir nesne örne?i olu?turur. 
//--Hafif ve payla??labilir olmayan yap?lar için daha uygundur.
//**Her istek için ba??ms?z bir durum olmas?n? istiyorsak.
//**Payla??lmas? gereken durum yoksa

//builder.Services.AddScoped
//--Her istek(Request) için ayn? nesne kullan?r.?ste?in ya?am döngüsü boyunca ayn? nesne üzerinde ilerlemesini sa?lar.
//**Http iste?i süresince ayn? örne?i payla?mas?n? istiyorsan?z.
//**Ayn? istek içerinde birden fazla kez ayn? hizmeti kullanmak istiyorsan?z.
//**Veritaban? gibi ortak kaynaklar? payla?mak için

//builder.Services.AddSingleton
//--Uygulama boyunca ayn? nesne üzerinde ilerlemeyi sa?lar.
//**Uygulama servisinde yap?land?rma ayarlar? veya önbellek verileri için.

builder.Services.AddTransient<IMyService, XMyService>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
