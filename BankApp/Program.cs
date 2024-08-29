
using BankApp.DAL;
using BankApp.Interface;
using BankApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<BankDbContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepo<>));
builder.Services.AddScoped<IBank, BankRepository>();
builder.Services.AddScoped<IAccount, AccountRepository>();
builder.Services.AddScoped<ILoan, LoanRepository>();
builder.Services.AddScoped<IUser, UserRepository>();
builder.Services.AddScoped<ITransaction, TransactionRepository>();

builder.Services.AddControllers();





// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bank API Personal Project");
    });
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseEndpoints(endpoint => endpoint.MapControllers());

app.UseAuthorization();


app.Run();
