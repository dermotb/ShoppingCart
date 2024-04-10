using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
var movieApiKey = builder.Configuration["localDBString"];
builder.Services.AddDbContext<ItemsContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("AzureContext")));

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Shop}/{action=Index}/{id?}");

app.Run();
