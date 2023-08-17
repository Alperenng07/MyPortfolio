using Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.UI.Models;
using Portfolio.Business.Service.Auth;
using Portfolio.Business.Service.BaseService;
using Portfolio.Business.Service.Token;
using Repositories.Abstract;
using Repositories.Concrete;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
        option =>
        {
            option.MigrationsAssembly(Assembly.GetAssembly(typeof(DataContext))?.GetName().Name);
        });
});







builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IBaseService<User>, BaseService<User>>();
builder.Services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();

builder.Services.AddScoped<IBaseService<Comment>, BaseService<Comment>>();
builder.Services.AddScoped<IBaseRepository<Comment>, BaseRepository<Comment>>();


builder.Services.AddScoped<IBaseService<Offer>, BaseService<Offer>>();
builder.Services.AddScoped<IBaseRepository<Offer>, BaseRepository<Offer>>();


builder.Services.AddScoped<IBaseService<ModeratorFullViewModel>, BaseService<ModeratorFullViewModel>>();
builder.Services.AddScoped<IBaseRepository<ModeratorFullViewModel>, BaseRepository<ModeratorFullViewModel>>();

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.Cookie.Name = "NetCoreMvc.Auth";
    options.LoginPath = "/Login/Index";
    options.AccessDeniedPath = "/Login/Index";
});




var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DataContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();