using Alura.Adopet.API.Controladores;
using Alura.Adopet.API.Dados.Context;
using Alura.Adopet.API.Service.Interface;
using Alura.Adopet.API.Startup;
using APICatalogo.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

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
builder.Services.AddSwaggerGen(opts =>
{
    opts.SwaggerDoc("v1", new Info
    {
        Version = "v1",
        Title = "Adopet API",
        Description = "<h1>Adopet API</h1>" +                   
                      "<h3>Adopet API é uma aplicação ASP.NET Core Web API, que mantem um cadastro de Pets e de seus proprietários.</h3>",      
   
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    opts.IncludeXmlComments(xmlPath);

});

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
