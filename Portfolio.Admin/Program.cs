using Entities;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Portfolio.Business.Service.Auth;
using Portfolio.Business.Service.BaseService;
using Portfolio.Business.Service.Token;
using Repositories.Abstract;
using Repositories.Concrete;

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

builder.Services.AddScoped<IBaseService<Skill>, BaseService<Skill>>();
builder.Services.AddScoped<IBaseRepository<Skill>, BaseRepository<Skill>>();

builder.Services.AddScoped<IBaseService<Language>, BaseService<Language>>();
builder.Services.AddScoped<IBaseRepository<Language>, BaseRepository<Language>>();

builder.Services.AddScoped<IBaseService<Education>, BaseService<Education>>();
builder.Services.AddScoped<IBaseRepository<Education>, BaseRepository<Education>>();

builder.Services.AddScoped<IBaseService<Experience>, BaseService<Experience>>();
builder.Services.AddScoped<IBaseRepository<Experience>, BaseRepository<Experience>>();

builder.Services.AddScoped<IBaseService<Project>, BaseService<Project>>();
builder.Services.AddScoped<IBaseRepository<Project>, BaseRepository<Project>>();

builder.Services.AddScoped<IBaseService<Job>, BaseService<Job>>();
builder.Services.AddScoped<IBaseRepository<Job>, BaseRepository<Job>>();

builder.Services.AddScoped<IBaseService<Moderator>, BaseService<Moderator>>();
builder.Services.AddScoped<IBaseRepository<Moderator>, BaseRepository<Moderator>>();

builder.Services.AddScoped<IBaseService<Offer>, BaseService<Offer>>();
builder.Services.AddScoped<IBaseRepository<Offer>, BaseRepository<Offer>>();

builder.Services.AddScoped<IBaseService<Comment>, BaseService<Comment>>();
builder.Services.AddScoped<IBaseRepository<Comment>, BaseRepository<Comment>>();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();