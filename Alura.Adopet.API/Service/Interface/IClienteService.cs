using Alura.Adopet.API.Dominio.Entity;

namespace Alura.Adopet.API.Service.Interface
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>?> BuscaClientAsync();
        Task SalvarCliente(Cliente obj);
    }
}
