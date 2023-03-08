using Alura.Adopet.API.Base;
using Alura.Adopet.API.Controladores;
using Alura.Adopet.API.Dados.Context;
using Alura.Adopet.API.Dados.Repository;
using Alura.Adopet.API.Dados.UofW;
using Alura.Adopet.API.Dominio.Entity;
using Alura.Adopet.API.Service;
using Alura.Adopet.API.Service.Interface;
using Alura.Adopet.API.Startup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);// Criando uma aplicação Web.

builder.Services.AddDbContext<DataBaseContext>(opt => 
{
  opt.UseInMemoryDatabase("AdopetDB");
});

builder.Logging.ClearProviders();
builder.Logging.AddConsole();


builder.Services.AddControllers().AddNewtonsoftJson(options =>
   options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

//DI
builder.Services.ConfigureDI();

//Habilitando o swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adicionando serviços.
var serviceProvider = builder.Services.BuildServiceProvider();
var eventoService = serviceProvider.GetService<IEventoService>();

var app = builder.Build();
eventoService.GenerateFakeDate();


// Ativando o Swagger
app.UseSwagger();
app.AddEndpointsPet();
app.AddEndpointsCliente();
// Ativando a interface Swagger
app.UseSwaggerUI(
    c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoAPI V1");
        c.RoutePrefix = string.Empty;
    }
);
// Roda a aplicação
app.Run();
