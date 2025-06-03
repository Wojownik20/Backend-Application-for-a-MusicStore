using System.Data;
using FluentValidation;
using FluentValidation.AspNetCore;
using LeverX.WebAPI.Validators;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MusicStore.Core.Db;
using MusicStore.Platform.Services.Extensions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFilename = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
}); // Swagger

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>()); // CQRS

builder.Services.AddDbContext<MusicStoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); //Connection to DataBase EF


builder.Services.AddTransient<IDbConnection>(sp =>
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"))); // Dapper connection

builder.Services.AddAutoMapper(typeof(Program)); // MApper configuration

builder.Services.AddValidatorsFromAssemblyContaining<CreateCustomerCommandValidator>();
builder.Services.AddFluentValidationAutoValidation(); // Fluent Validation
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>)); // Validation Behaviour


//Repositories and Services


builder.Services.RegisterPlatformServices();
builder.Services.RegisterPlatformRepositories();

var app = builder.Build();
app.UseMiddleware<ValidationExceptionMiddleware>(); // Middleware for validation exceptions

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
