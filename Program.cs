using imageupload.Data;
using imageupload.Repository;
using imageupload.Repository.Irepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string cs = builder.Configuration.GetConnectionString("constr");
builder.Services.AddDbContext<Applicationdbcontext>(options => options.UseSqlServer(cs));
builder.Services.AddScoped<Iunitofwork, Unitofwork>();
builder.Services.AddScoped<Ibikes, Bikes>();
builder.Services.AddControllers();

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
