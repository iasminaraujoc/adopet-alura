using Alura.Adopet.API.Dominio.Dto;
using FluentValidation;

namespace Alura.Adopet.API.Validations
{
    public class PetValidator:AbstractValidator<PetDTO>
    {
        public PetValidator()
        {
            RuleFor(x => x.Nome)
                .NotNull()
                .NotEmpty().WithMessage("Nome é obrigatório").
                Length(1, 80);

            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Id é obrigatório.");

            RuleFor(x => x.Tipo).IsInEnum().WithMessage("O tipo é uma enumeração (Gato,Cachorro,Reptil, PorcoDaIndia)");
        }

    }
}
