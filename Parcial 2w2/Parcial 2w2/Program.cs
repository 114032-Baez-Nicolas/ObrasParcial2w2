using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parcial_2w2.ModelsDatabase;
using Parcial_2w2.Repositories.Implementaciones;
using Parcial_2w2.Repositories.Interfaces;
using Parcial_2w2.Services.Implementaciones;
using Parcial_2w2.Services.Interfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//(1) Inyección de dependencias
builder.Services.AddScoped<IObrasRepository, ObraRepository>();
builder.Services.AddScoped<IAlbanileRepository, AlbanileRepository>();
builder.Services.AddScoped<IParcialService, ParcialService>();

//2) Base de datos (Normal)
builder.Services.AddDbContext<DbAa579fProg3w2Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//3) Automapper (Para mapear los DTOs)
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//4) Fluent Validation
builder.Services.AddFluentValidation((options) =>
{
    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});

//5) Manejar la clase base response
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//6) Cors
app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyHeader();
    options.AllowAnyMethod();
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
