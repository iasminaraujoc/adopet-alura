using Alura.Adopet.API.Dominio.Entity;
using Alura.Adopet.API.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Alura.Adopet.API.Controladores
{
    public static class EndpointsPet
    {
        public static void AddEndpointsPet(this WebApplication app)
        {

            #region Pet
            //Endpoints
            app.MapPost("v1/pet/salvar-pet", ([FromServices] IPetService service, [FromBody] Pet pet) =>
            {
                return service.SalvarPet(pet);
            });

            // Listar todas os pets.
            app.MapGet("v1/pet/listar-pet", async ([FromServices] IPetService service) =>
            {
                return Results.Ok(await service.BuscaPetAsync());
            });
            #endregion

        }
    }
}
