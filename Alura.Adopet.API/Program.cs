using Alura.Adopet.API.Controladores;
using Alura.Adopet.API.Dados.Context;
using Alura.Adopet.API.Dominio.Dto;
using Alura.Adopet.API.Service.Interface;
using Alura.Adopet.API.Startup;
using Alura.Adopet.API.Validations;
using APICatalogo.Extensions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);// Criando uma aplica��o Web.

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
builder.Services.AddAutoMapper(typeof(Program));

//Habilitando o swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adicionando servi�os.
var serviceProvider = builder.Services.BuildServiceProvider();
var eventoService = serviceProvider.GetService<IEventoService>();

//Gerando dados fake.
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
app.ConfigureExceptionHandler();
// Roda a aplica��o
app.Run();
