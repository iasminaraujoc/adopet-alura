using Alura.Adopet.API.Dados.Repository.Interface.Repository;

namespace Alura.Adopet.API.Dados.UofW
{
    public interface IUofW
    {
        IClienteRepository ClienteRepository { get; }
        IPetRepository PetRepository { get; }
        void Commit();
    }
}
