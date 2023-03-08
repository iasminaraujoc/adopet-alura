using Alura.Adopet.API.Base;
using Alura.Adopet.API.Dados.Context;
using Alura.Adopet.API.Dados.Repository.Interface.Repository;
using Alura.Adopet.API.Dominio.Entity;
using Microsoft.EntityFrameworkCore;

namespace Alura.Adopet.API.Dados.Repository
{
    public class PetRepository : BaseRepository<Pet>,IPetRepository
    {
        private readonly DataBaseContext _context;
        public PetRepository(DataBaseContext context) : base(context) {
            _context = context;
        }

        public override async Task<IEnumerable<Pet?>> Get()
        {
            return await this._context.Pets.Include(x=>x.Proprietario).ToListAsync();                  
         

        }
    }
}
