using Alura.Adopet.API.Dominio.Dto;
using Alura.Adopet.API.Dominio.Entity;

namespace Alura.Adopet.API.Service.Interface
{
    public interface IPetService
    {
        Task<IEnumerable<PetDTO>?> BuscaPetAsync();
        Task SalvarPet(PetDTO obj);
        PetDTO BuscarPorID(Guid id);
    }
}
