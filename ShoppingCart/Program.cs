using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;
using System.Configuration;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var movieApiKey = builder.Configuration["localDBString"];
builder.Services.AddDbContext<ItemsContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("AzureContext")));
options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDevContext")));


builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ItemsContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/ItemsDB/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Shop}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
