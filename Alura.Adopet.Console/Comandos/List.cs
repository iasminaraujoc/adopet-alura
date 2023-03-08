using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services;

namespace Alura.Adopet.Console.Comandos
{
    internal class List : IComando
    {
        PetService clientPet;

        public List()
        {
            clientPet = new PetService();
        }

        //public string Documentacao => $" adopet list  comando que exibe no terminal o conteúdo importado no servidor.";
        [DocAttributes("list")]
        public string Documentacao;
        public async Task ExecutarAsync(string[] args)
        {
            await this.ListPets();
        }

        public async Task ListPets()
        {
            var pets = await clientPet.ListAsync();
            foreach (var pet in pets)
            {
                System.Console.WriteLine(pet);
            }
            System.Console.ReadKey();
        }

    }
}
