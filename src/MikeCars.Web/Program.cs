using MikeCars.Application.Interfaces;
using MikeCars.Application.Services;
using MikeCars.Domain.Interfaces.Repositories;
using MikeCars.Domain.Interfaces.Services;
using MikeCars.Domain.Services;
using MikeCars.Infraestructure.CrossCutting.Builders;
using MikeCars.Infraestructure.Repository.Repositories.Internal;

var builder = WebApplication.CreateBuilder(args);

DbUpBuider.BuildDatabaseMigration();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IEmployeeAppService, EmployeeAppService>();
builder.Services.AddScoped<IFuncionarioService, FuncionarioService>();

builder.Services.AddScoped<IDocumentoRepository, DocumentoRepository>();
builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();


var app = builder.Build();

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
    pattern: "{controller=Employee}/{action=Index}/{id?}");

app.Run();
