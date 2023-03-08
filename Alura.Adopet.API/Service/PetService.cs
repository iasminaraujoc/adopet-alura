using Alura.Adopet.API.Dados.UofW;
using Alura.Adopet.API.Dominio.Dto;
using Alura.Adopet.API.Dominio.Entity;
using Alura.Adopet.API.Service.Interface;
using AutoMapper;

namespace Alura.Adopet.API.Service
{
    public class PetService : IPetService
    {
        private readonly IUofW _uofW;
        private readonly IMapper _mapper;
        public PetService(IUofW uofW, IMapper mapper)
        {
            this._uofW = uofW;
            this._mapper = mapper;
        }
        public async Task<IEnumerable<PetDTO>?> BuscaPetAsync()
        {
            var retorno = await _uofW.PetRepository.Get();
            IEnumerable<PetDTO> petsDTO = _mapper.Map<IEnumerable<Pet>, IEnumerable<PetDTO>>(retorno);
            return petsDTO;
        }    

        public Task SalvarPet(PetDTO? obj)
        {
            var retorno = _mapper.Map<PetDTO, Pet>(obj);
            _uofW.PetRepository.Add(retorno);
            _uofW.Commit();
            return Task.CompletedTask;
          
        }

     
    }
}
