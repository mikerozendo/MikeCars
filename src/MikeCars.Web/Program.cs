using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MikeCars.Infraestructure.Repository.Context;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;
DbConnection dbConnection = new SqlConnection(configuration.GetConnectionString("App"));

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(dbConnection, 
    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

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
    pattern: "{controller=Employee}/{action=Index}/{id?}");

app.Run();
