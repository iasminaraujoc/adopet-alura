using System.ComponentModel.DataAnnotations;

namespace Alura.Adopet.API.Dominio.Dto
{
    public class ClienteDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
