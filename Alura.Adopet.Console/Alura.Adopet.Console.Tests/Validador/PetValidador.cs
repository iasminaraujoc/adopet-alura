using FluentValidation;

namespace Alura.Adopet.Console.Tests.Validador
{
    internal class PetValidador : AbstractValidator<Pet>
    {
        public PetValidador()
        {
            RuleFor(a => a.Nome).NotNull().WithMessage("Nome não pode ser nulo.").
                NotEmpty().WithMessage("Nome não pode ser vazio.").
                MinimumLength(3).WithMessage("Mínimo de 3 caracteres.");
                       
            RuleFor(a => a.Id).NotEmpty().WithMessage("O Id não pode ser vazio.");

            RuleFor(a => a.Tipo).Must(x => Enum.IsDefined(typeof(TipoPet), x)).WithMessage("Tipo de Pet não definido.");

            
        }
    }
}
