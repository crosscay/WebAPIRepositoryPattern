using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPIRepositoryPattern.Models;
using WebAPIRepositoryPattern.Repository;

var builder = WebApplication.CreateBuilder(args);


//public static void Main(string[] args)
//{
//    CreateHostBuilder(args).Build().Run();
//}

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// CONFIGURAR Y INICIALIZAR EL DBCONTEXT
builder.Services.AddDbContext<ApplicationDBContext>(dbContextOption => dbContextOption.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
