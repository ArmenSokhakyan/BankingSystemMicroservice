using Microsoft.EntityFrameworkCore;
using TransactionManagementSystem.Core.Interfaces.Repositories;
using TransactionManagementSystem.Core.Interfaces.Services;
using TransactionManagementSystem.Core.Services;
using TransactionManagementSystem.Infrastructure.Data;
using TransactionManagementSystem.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configuration = builder.Configuration;

builder.Services.AddDbContext<TransactionContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

//Register repositories
builder.Services.AddScoped<IInTransactionRepository, InTransactionRepository>();
builder.Services.AddScoped<IOutTransactionRepository, OutTransactionRepository>();
builder.Services.AddScoped<ITransferTransactionRepository, TransferTransactionRepository>();
builder.Services.AddScoped<ISummeryRepository, SummeryRepository>();

//Register services
builder.Services.AddScoped<IInTransactionService, InTransactionService>();
builder.Services.AddScoped<IOutTransactionService, OutTransactionService>();
builder.Services.AddScoped<ITransferTransactionService, TransferTransactionService>();
builder.Services.AddScoped<ISummeryService, SummeryService>();

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
