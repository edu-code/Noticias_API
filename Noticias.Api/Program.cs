using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Noticias.Application.DTOs;
using Noticias.Application.Interfaces;
using Noticias.Application.Services;
using Noticias.Domain.Entities;
using Noticias.Domain.Repositories;
using Noticias.Infra.Contexts;
using Noticias.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region MySql

// var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//
// var serverVersion = new MySqlServerVersion(ServerVersion.AutoDetect(connectionString));
//
// builder.Services.AddDbContext<NoticiaContext>(dbContextOptions =>
// {
//     dbContextOptions
//         .UseMySql(connectionString, serverVersion)
//         .LogTo(Console.WriteLine, LogLevel.Information)
//         .EnableSensitiveDataLogging()
//         .EnableDetailedErrors();
// });

#endregion
#region Mapper

var autoMapperConfig = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<NoticiaDto, Noticia>().ReverseMap();
    cfg.CreateMap<UpdateNoticiaDto, Noticia>().ReverseMap();
});

builder.Services.AddSingleton(autoMapperConfig.CreateMapper());

builder.Services.AddSingleton(d => builder.Configuration);
builder.Services.AddDbContext<NoticiaContext>(options => options.UseMySql("Server=localhost;Port=3306;Database=Noticiasdb;Uid=root;Pwd=Lab@inf019;", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql")));

builder.Services.AddScoped<INoticiaRepository, NoticiaRepository>();
builder.Services.AddScoped<INoticiaService, NoticiaService>();

#endregion

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