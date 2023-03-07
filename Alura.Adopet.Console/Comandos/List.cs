using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services;

namespace Alura.Adopet.Console.Comandos
{
    internal class List
    {
        PetService clientPet;

        public List()
        {
            clientPet = new PetService();
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
