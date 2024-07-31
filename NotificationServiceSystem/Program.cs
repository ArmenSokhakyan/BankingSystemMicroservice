using Microsoft.EntityFrameworkCore;
using NotificationServiceSystem.Core.Interfaces.Repositories;
using NotificationServiceSystem.Core.Interfaces.Services;
using NotificationServiceSystem.Core.Services;
using NotificationServiceSystem.Infrastructure.Data;
using NotificationServiceSystem.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configuration = builder.Configuration;

builder.Services.AddDbContext<NotificationContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

//Register repositories
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();

//Register services
builder.Services.AddScoped<INotificationService, NotificationService>();

//Mapper registration
builder.Services.AddAutoMapper(typeof(Program));

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

public partial class Program { }
