using MEC.ControleRDO.Business.Implementations;
using MEC.ControleRDO.Business;
using MEC.ControleRDO.Context;
using MEC.ControleRDO.Repository.Generic;
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
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<ISessionBusiness, SessionBusinessImplementation>();
builder.Services.AddScoped<IFiscalBusiness, FiscalBusinessImplementation>();
builder.Services.AddScoped<IObraBusiness, ObraBusinessImplementation>();
builder.Services.AddScoped<IRdoBusiness, RdoBusinessImplementation>();
builder.Services.AddScoped<IUsuarioBusiness, UsuarioImplementation>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

builder.Services.AddSession(o =>
{
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
});

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

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");



app.Run();
