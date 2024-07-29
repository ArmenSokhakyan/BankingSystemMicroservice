using ReferanceManagementSystem.Core.Interfaces.Repositories;
using ReferanceManagementSystem.Infrastructure.Data;
using ReferanceManagementSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using ReferanceManagementSystem.Core.Services;
using ReferanceManagementSystem.Core.Interfaces.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configuration = builder.Configuration;

builder.Services.AddDbContext<RMSContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

//Register repositories
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

//Register services
builder.Services.AddScoped<IAccountService, AccountService>();

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
