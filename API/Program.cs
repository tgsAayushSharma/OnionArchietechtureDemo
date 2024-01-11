using BusinessLogic;
using DataAccess.DataActions;
using DataAccess.DataActions.Interface;
using DataAccess.Models;
using Service;
using Service.Interface;
using Service.Mappers;
using Service.Mappers.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<EmployeeContext>();
builder.Services.AddScoped<IDataAction, DataActionClass>();
builder.Services.AddTransient<IServices, ServicesClass>();
builder.Services.AddTransient<IDtoToEntityMappers, DtoToEntityMappers>();
builder.Services.AddTransient<IDtoToDomainMappers, DtoToDomainMappers>();
builder.Services.AddTransient<IDomainToEntityMappers, DomainToEntityMappers>();

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

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
