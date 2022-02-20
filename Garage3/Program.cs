using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Garage3.Data;
using Garage3.Extensions;
using Garage3.Automapper;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<Garage3Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Garage3Context")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(GarageMappings));

var app = builder.Build();

app.SeedDataAsync().GetAwaiter().GetResult();



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
