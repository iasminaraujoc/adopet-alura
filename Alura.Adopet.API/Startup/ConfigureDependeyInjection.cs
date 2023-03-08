using Alura.Adopet.API.Dados.Context;
using Alura.Adopet.API.Dados.Repository;
using Alura.Adopet.API.Service.Interface;
using Alura.Adopet.API.Service;
using Microsoft.EntityFrameworkCore;
using Alura.Adopet.API.Dados.UofW;
using Alura.Adopet.API.Validations;
using Alura.Adopet.API.Dominio.Dto;
using FluentValidation;

namespace Alura.Adopet.API.Startup
{
    public static class ConfigureDependeyInjection
    {
        public static void ConfigureDI(this IServiceCollection service)
        {

            service.AddScoped<DataBaseContext>();            
            service.AddScoped<ClienteRepository>();
            service.AddScoped<PetRepository>();
            service.AddScoped<IEventoService, EventoService>();
            service.AddScoped<IPetService, PetService>();
            service.AddScoped<IClienteService, ClienteService>();
            service.AddScoped<IValidator<PetDTO>,PetValidator >();
            service.AddScoped<IUofW, UofW>();

        }
    }
}
