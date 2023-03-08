using Alura.Adopet.API.Dados.Context;
using Alura.Adopet.API.Dados.UofW;
using Alura.Adopet.API.Dominio.Entity;
using Alura.Adopet.API.Dominio.Enum;
using Alura.Adopet.API.Service.Interface;

namespace Alura.Adopet.API.Service
{
    internal class EventoService : IEventoService
    {
        private IPetService _petService;

        public EventoService(IPetService petService)
        {
            this._petService = petService;           
        }

        public void GenerateFakeDate()
        {          

            var pet = new Pet()
            {
                Nome = "Sábio",
                Tipo = TipoPet.Gato,
                Proprietario = new Cliente()
                {
                    CPF = "111.111.111-22",
                    Nome = "André",
                    Email = "andre@email.com"
                }
            };
           _petService.SalvarPet(pet);
           
        }
    }
}
