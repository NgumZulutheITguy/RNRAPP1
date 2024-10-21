using Microsoft.EntityFrameworkCore;
using RNRAPP.Data;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BreakdownDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("BreakdownDbContext")
    ));

var app = builder.Build();



// Enable Cors 
var allowedOrigins = new[] { "http://localhost:3000" };

app.UseCors(policy =>
    policy.AllowAnyHeader()
          .AllowAnyMethod()
          .WithOrigins("http://localhost:3000") // 
          .AllowCredentials());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowOrigin");
app.UseAuthorization();
  
app.MapControllers();

app.Run();
