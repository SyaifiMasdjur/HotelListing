using HotelListing.Net6.Configurations;
using HotelListing.Net6.Contracts;
using HotelListing.Net6.Data;
using HotelListing.Net6.Repositories;
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
builder.Host.UseSerilog((context, loggerconfig) =>
{
    loggerconfig.WriteTo.Console().ReadFrom
                        .Configuration(context.Configuration);
});

//AutoMapper
builder.Services.AddAutoMapper(typeof(MapperConfig));


//Repository
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ICountryRepository,CountryRepository>();
builder.Services.AddScoped<IHotelsRepository,HotelRepository>();


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
