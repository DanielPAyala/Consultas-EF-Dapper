using Consultas.Entidades;
using Consultas.IRepositories;
using Consultas.IServices;
using Consultas.Repositories;
using Consultas.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ConsultasContext>(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("ConexionDB"))
);

builder.Services.AddSingleton<DapperContext>();

var ORM = builder.Configuration["Parametros:ORM"];
switch (ORM)
{
    case "DAPPER":
        builder.Services.AddScoped<IConsultasService, DapperService>();
        builder.Services.AddScoped<IConsultasRepository, DapperRepository>();
        break;
    case "LINQ":
        builder.Services.AddScoped<IConsultasService, JoinsService>();
        builder.Services.AddScoped<IConsultasRepository, JoinsRepository>();
        break;
    default:
        builder.Services.AddScoped<IConsultasService, JoinsService>();
        builder.Services.AddScoped<IConsultasRepository, JoinsRepository>();
        break;
}


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
