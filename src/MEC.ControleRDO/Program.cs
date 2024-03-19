using MEC.ControleRDO.Business.Implementations;
using MEC.ControleRDO.Business;
using MEC.ControleRDO.Context;
using MEC.ControleRDO.Repository.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddRazorPages();

var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
builder.Services.AddDbContext<ControleRdoContext>(options => options.UseMySql(
    connection,
    new MySqlServerVersion(new Version(8, 0, 29)))
);

//Dependency Injection

builder.Services.AddScoped<IFiscalBusiness, FiscalBusinessImplementation>();
builder.Services.AddScoped<IObraBusiness, ObraBusinessImplementation>();
builder.Services.AddScoped<IRdoBusiness, RdoBusinessImplementation>();
builder.Services.AddScoped<IUsuarioBusiness, UsuarioImplementation>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

var app = builder.Build();


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
