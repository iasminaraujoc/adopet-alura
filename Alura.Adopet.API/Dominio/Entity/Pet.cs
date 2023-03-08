using System.ComponentModel.DataAnnotations;
using Alura.Adopet.API.Dominio.Enum;

namespace Alura.Adopet.API.Dominio.Entity
{
    public class Pet
    {
        public Pet()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public TipoPet Tipo { get; set; }
        public Cliente? Proprietario { get; set; }
    }
}
