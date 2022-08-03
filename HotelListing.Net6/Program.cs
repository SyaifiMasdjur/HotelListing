using HotelListing.Net6.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("HotelDBConnectionString");

builder.Services.AddDbContext<HotelDBContext>(o => { o.UseSqlServer(connectionString); });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//add cors
builder.Services.AddCors(o =>
{
    o.AddPolicy("AllowALl", p => p.AllowAnyMethod()
    .AllowAnyHeader()
    .AllowAnyOrigin());
});

//serilog context=>builder context
builder.Host.UseSerilog((context, loggerconfig) => { 
    loggerconfig.WriteTo.Console().ReadFrom
                        .Configuration(context.Configuration);
});
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
