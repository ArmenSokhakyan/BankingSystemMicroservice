using FrontEnd.Core.Common;
using FrontEnd.Core.Interfaces.Services.Referances;
using FrontEnd.Core.Interfaces.Services.Transactions;
using FrontEnd.Core.Services.Referances;
using FrontEnd.Core.Services.Transactions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configuration = builder.Configuration;

builder.Services.AddHttpClient<IAccountService, AccountService>();
builder.Services.AddHttpClient<IInTransactionService, InTransactionService>();
builder.Services.AddHttpClient<IOutTransactionService, OutTransactionService>();
builder.Services.AddHttpClient<ITransferTransactionService, TransferTransactionService>();
builder.Services.AddHttpClient<ISummeryService, SummeryService>();

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IInTransactionService, InTransactionService>();
builder.Services.AddScoped<IOutTransactionService, OutTransactionService>();
builder.Services.AddScoped<ITransferTransactionService, TransferTransactionService>();
builder.Services.AddScoped<ISummeryService, SummeryService>();

Constants.AccountUrlBase = configuration.GetValue<string>("ServiceUrls:AccountsUrl");
Constants.TransactionUrlBase = configuration.GetValue<string>("ServiceUrls:TransactionsUrl");

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
