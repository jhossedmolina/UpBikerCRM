using Microsoft.EntityFrameworkCore;
using UpBikerCRM.Core.Interfaces;
using UpBikerCRM.Core.Services;
using UpBikerCRM.Infraestructure.Data;
using UpBikerCRM.Infraestructure.Mappings;
using UpBikerCRM.Infraestructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UpBikerCrmdbContext>(cf => 
    cf.UseSqlServer(builder.Configuration.GetConnectionString("UpbikerCRMDB")));

builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();

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
