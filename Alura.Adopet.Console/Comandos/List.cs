using System.Net.Http.Headers;
using System.Net.Http.Json;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Console.Comandos
{
    internal class List
    {
        // cria instância de HttpClient para consumir API Adopet
        HttpClient client;
        HttpClientPet clientPet;
        public List()
        {
            clientPet = new HttpClientPet();
            client = clientPet.GetHttpClient();
        }
        public async Task<IEnumerable<Pet>?> ListPetsAsync()
        {
            HttpResponseMessage response = await client.GetAsync("v1/pet/listar");
            return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
        }

        public async Task ListPets()
        {
            var pets = await ListPetsAsync();
            foreach (var pet in pets)
            {
                System.Console.WriteLine(pet);
            }
            System.Console.ReadKey();
        }

    }
}
