using Microsoft.EntityFrameworkCore;
using MVC_TravelTrip.Models.Sinifler;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Context>(options =>
options.UseSqlServer(
    builder.Configuration.GetConnectionString("conn")));



// Add services to the container.


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/GirisYap/Login";   // yetkisiz kiþi buraya gönderilir
    });
builder.Services.AddSession();
var app = builder.Build();

// Veritabanýný hazýrla ve ilk açýlýþta demo admin ekle
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<Context>();
    db.Database.Migrate();

    if (!db.Admins.Any())
    {
        db.Admins.Add(new Admin { Kullanici = "admin", Sifre = "Demo123!" });
        db.SaveChanges();
    }
}

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
app.UseSession();


app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
