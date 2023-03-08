using Alura.Adopet.API.Dominio.Dto;
using Alura.Adopet.API.Dominio.Entity;
using AutoMapper;

namespace Alura.Adopet.API.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Cliente,ClienteDTO>();
            CreateMap<Pet, PetDTO>();

            CreateMap<ClienteDTO,Cliente>();
            CreateMap<PetDTO,Pet>();
        }
    }

}
