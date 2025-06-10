using System.Text.Json;
using LeverX.WebAPI.Extensions;
using LeverX.WebAPI.Middleware.ValidationMiddleware;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using MusicStore.Core.Db;
using MusicStore.Identity.Db;
using MusicStore.Platform.Services.Extensions;
using MusicStore.WebApi.Extensions;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFilename = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

builder.Services.RegisterDbContext(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerDocumentation();
builder.Services.AddHealthChecks()
    .AddDbContextCheck<MusicStoreContext>("MainDb")
    .AddDbContextCheck<IdentityDbContext>("IdentityDb");


builder.Services.RegisterPlatformServices();
builder.Services.RegisterPlatformRepositories();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("PremiumOnly", policy =>
        policy.RequireClaim("IsPremiumUser", "True"));
});

var app = builder.Build();
app.UseMiddleware<ValidationExceptionMiddleware>();

var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("🚀 Application started successfully at {Time}", DateTime.UtcNow);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthCheckEndpoint();

app.Run();


