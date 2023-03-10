using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.UI;

namespace Alura.Adopet.Console.Comandos
{
    internal class List : IComando
    {
        PetService clientPet;

        public List()
        {
            clientPet = new PetService();
        }

        public string Documentacao => $" adopet list  comando que exibe no terminal o conteúdo importado no servidor.";

        public async Task<List<string>> ExecutarAsync(string[] args)
        {
            return await this.ListPets();
        }

        public async Task<List<string>> ListPets()
        {
            var retorno = new List<string>();
            var pets = await clientPet.ListAsync();
            foreach (var pet in pets)
            {
                retorno.Add(pet.ToString());
            }              
            return retorno; 
        }

    }
}
