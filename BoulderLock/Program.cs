using Microsoft.EntityFrameworkCore;
using BoulderLock.Data;
using BoulderLock.Services.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
<<<<<<< HEAD
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
=======
var connectionString = builder.Configuration.GetConnectionString("BoulderLock");
>>>>>>> 7f91d92d4733a8b709e50b5aeb04e564a68ef3ff
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IUserService, UserService>();

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
