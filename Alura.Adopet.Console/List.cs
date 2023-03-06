using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Alura.Adopet.Console
{
    internal class List
    {
        // cria instância de HttpClient para consumir API Adopet
        HttpClient client;
        HttpClientPet clientPet;
        public List()
        {
            this.clientPet = new HttpClientPet();
            this.client = clientPet.GetHttpClient();
        }
        public async Task<IEnumerable<Pet>?> ListPetsAsync()
        {
            HttpResponseMessage response = await client.GetAsync("pet/list");
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
