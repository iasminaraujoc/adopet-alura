﻿using Alura.Adopet.API.Dominio.Entity;
using Alura.Adopet.API.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Alura.Adopet.API.Controladores
{
    public static class EndpointsCliente
    {
        public static void AddEndpointsCliente(this WebApplication app)
        {

            #region cliente     
            // Listar todas os clientes.
            app.MapGet("v1/cliente/listar", async ([FromServices] IClienteService service) =>
            {
                return Results.Ok(await service.BuscaClientAsync());
            });
            #endregion

        }
    }
}
