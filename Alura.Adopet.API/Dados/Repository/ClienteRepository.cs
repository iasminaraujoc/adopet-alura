using Alura.Adopet.API.Base;
using Alura.Adopet.API.Dados.Context;
using Alura.Adopet.API.Dados.Repository.Interface.Repository;
using Alura.Adopet.API.Dados.UofW;
using Alura.Adopet.API.Dominio.Entity;
using System;

namespace Alura.Adopet.API.Dados.Repository
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {

        private readonly DataBaseContext _context;
        public ClienteRepository(DataBaseContext context) : base(context) { }
    }
       
}
