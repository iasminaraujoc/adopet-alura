using Alura.Adopet.API.Dominio.Entity;

namespace Alura.Adopet.API.Service.Interface
{
    public interface IPetService
    {
        Task<IEnumerable<Pet>?> BuscaPetAsync();
        Task SalvarPet(Pet obj);
    }
}
