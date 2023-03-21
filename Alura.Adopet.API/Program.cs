using Alura.Adopet.API.Controladores;
using Alura.Adopet.API.Dados.Context;
using Alura.Adopet.API.Service.Interface;
using Alura.Adopet.API.Startup;
using APICatalogo.Extensions;

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

builder.Services.ConfigureDI();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adicionando serviços.
var serviceProvider = builder.Services.BuildServiceProvider();
var eventoService = serviceProvider.GetService<IEventoService>();
//Gerando dados fake.
var app = builder.Build();
eventoService.GenerateFakeDate();

app.UseSwagger();
app.AddEndpointsPet();
app.AddEndpointsCliente();
app.ConfigureSwaggerApp();
app.ConfigureExceptionHandler();

app.Run();
