using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.UI;

namespace Alura.Adopet.Console.Comandos
{
    [Util.DocComando($" adopet list  comando que exibe no terminal o conteúdo importado no servidor.")]
    internal class List : IComando
    {
        PetService clientPet;

        public List()
        {
            clientPet = new PetService();
        }

        public async Task<IResultado> ExecutarAsync(string[] args)
        {
            try
            {
                return await this.ListPets();
            }
            catch (Exception ex)
            {
                return new Erro(ex.Message);
            }
        }

        public async Task<IResultado> ListPets()
        {
            var pets = await clientPet.ListAsync();
            return new Ok(pets);
        }

    }
}
