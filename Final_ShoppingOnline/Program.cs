using Final_ShoppingOnline.Models;
using Final_ShoppingOnline.Repository.Data;
using Final_ShoppingOnline.Repository.Interfaces;
using Final_ShoppingOnline.Repository.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Final"));
});
//cấu hình Depedency Injection
builder.Services.AddScoped<IProductService, ProductService>();
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

////Seeding Data
//var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
//GenerateTestData.SeedingData(context);
    
app.Run();
