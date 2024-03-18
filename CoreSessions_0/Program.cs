using CoreSessions_0.Models.ContextClasses;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<NorthwindContext>(x => x.UseSqlServer().UseLazyLoadingProxies());

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(
    x =>
    {
        x.IdleTimeout = TimeSpan.FromMinutes(3);
        x.Cookie.HttpOnly = true;
        x.Cookie.IsEssential = true;
    });

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Category}/{action=GetCategories}/{id?}");

app.Run();
