using Alura.Adopet.API.Dados.UofW;
using Alura.Adopet.API.Dominio.Entity;
using Alura.Adopet.API.Service.Interface;

namespace Alura.Adopet.API.Service
{
    public class PetService : IPetService
    {
        private readonly IUofW _uofW;
        public PetService(IUofW uofW)
        {
           this._uofW = uofW;
        }
        public async Task<IEnumerable<Pet>?> BuscaPetAsync()
        {
            return await _uofW.PetRepository.Get();
        }    

        public Task SalvarPet(Pet? obj)
        {
            _uofW.PetRepository.Add(obj);
            _uofW.Commit();
            return Task.CompletedTask;
          
        }

     
    }
}
