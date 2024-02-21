using Microsoft.EntityFrameworkCore;
using TestTask;
using TestTask.Data;
using TestTask.Data.Implementations;
using TestTask.Data.Interfaces;
using TestTask.Models;
using TestTask.Services.Implementations;
using TestTask.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Addadded ->

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//-> there
builder.Services.AddScoped<IOrderService, OrderService>()
    .AddScoped<IUserService, UserService>()
    .AddScoped<IRepository<User>, UserRepository>()
    .AddScoped<IRepository<Order>, OrderRepository>();

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
