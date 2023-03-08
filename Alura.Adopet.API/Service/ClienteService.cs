using Alura.Adopet.API.Dados.UofW;
using Alura.Adopet.API.Dominio.Entity;
using Alura.Adopet.API.Service.Interface;

namespace Alura.Adopet.API.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IUofW _uofW;
        public ClienteService(IUofW uofW)
        {
           this._uofW = uofW;
        }
        public async Task<IEnumerable<Cliente>?> BuscaClientAsync()
        {
            return await _uofW.ClienteRepository.Get();
        }    

        public Task SalvarCliente(Cliente? obj)
        {
            _uofW.ClienteRepository.Add(obj);
            _uofW.Commit();
            return Task.CompletedTask;
          
        }

     
    }
}
