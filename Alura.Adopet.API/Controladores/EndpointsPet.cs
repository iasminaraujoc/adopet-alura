using Alura.Adopet.API.Dominio.Dto;
using Alura.Adopet.API.Dominio.Entity;
using Alura.Adopet.API.Service.Interface;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Alura.Adopet.API.Controladores
{
    public static class EndpointsPet
    {
        public static void AddEndpointsPet(this WebApplication app)
        {

            #region Pet
            //Endpoints
            app.MapPost("v1/pet/salvar", ([FromServices] IPetService service,[FromServices]IValidator<PetDTO> validator,[FromBody] PetDTO pet) =>
            {
                var validation =  validator.Validate(pet);
                if (!validation.IsValid)
                {
                    var mensagem = string.Empty;
                    foreach (var item in validation.ToDictionary())
                    {     
                        foreach (var  itemvalue in item.Value)
                        {
                            mensagem = mensagem + $" { itemvalue } ";
                    
                        }
                    };

                    return Results.Problem(mensagem);
                }

                return Results.Ok(service.SalvarPet(pet));
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
