using Alura.Adopet.API.Dominio.Dto;
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
            app.MapPost("v1/pet/salvar", ([FromServices] IPetService service, [FromBody] PetDTO pet) =>
            {
                return service.SalvarPet(pet);
            });

            // Listar todas os pets.
            app.MapGet("v1/pet/listar", async ([FromServices] IPetService service) =>
            {
                return Results.Ok(await service.BuscaPetAsync());
            });
            #endregion

        }
    }
}
