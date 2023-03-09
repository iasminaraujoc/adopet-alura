using Alura.Adopet.API.Dados.Context;
using Alura.Adopet.API.Dados.Repository;
using Alura.Adopet.API.Dados.Repository.Interface.Repository;


namespace Alura.Adopet.API.Dados.UofW
{
    public class UofW:IUofW
    {
        private ClienteRepository _clienteRepository;

        private PetRepository _petRepository;

        public DataBaseContext _context;

        public UofW(DataBaseContext context)
        {
            _context= context;
        }

        public IClienteRepository ClienteRepository
        {
            get
            {
                return _clienteRepository = _clienteRepository ?? new ClienteRepository(_context);
            }
        }

        public IPetRepository PetRepository
        {
            get
            {
                return _petRepository = _petRepository ?? new PetRepository(_context);
            }
        }

        public void Commit()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
