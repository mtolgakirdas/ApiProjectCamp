using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Entities;
using ApiProjectCamp.WebApi.ValidationRules;
using FluentValidation;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApiContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());//AutoMapper 'ý enjeksiyonu(dependcy injection)ile projeye ekleyerek tüm mapping iþlemlerini otomatik yükler.
builder.Services.AddScoped<IValidator<Product>,ProductValidator>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
