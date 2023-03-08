using Alura.Adopet.API.Dominio.Entity;
using Alura.Adopet.API.Dominio.Entity.Enum;
using System.ComponentModel.DataAnnotations;

namespace Alura.Adopet.API.Dominio.Dto
{
    public class PetDTO
    {
        
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public TipoPet Tipo { get; set; }
        public ClienteDTO? Proprietario { get; set; }
    }
}
