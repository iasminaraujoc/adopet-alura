using Alura.Adopet.API.Dominio.Dto;
using Alura.Adopet.API.Service.Interface;
using FluentValidation;

namespace Alura.Adopet.API.Validations
{
    public class PetValidator:AbstractValidator<PetDTO>
    {
        private IPetService _service;
        public PetValidator(IPetService service)
        {
            _service = service;
            RuleFor(x => x.Nome)
                .NotNull()
                .NotEmpty().WithMessage("Nome é obrigatório").
                Length(1, 80);

            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Id é obrigatório.");

            RuleFor(x=>x.Id).NotEmpty().Must(ValidaId).WithMessage("Esse código de PET já existe na base.");

            RuleFor(x => x.Tipo).IsInEnum().WithMessage("O tipo é uma enumeração (Gato,Cachorro,Reptil, PorcoDaIndia)");
        }

        private bool ValidaId(Guid id)
        {           
            
            return _service.BuscarPorID(id) != null ? false : true;
        }
    }
}
