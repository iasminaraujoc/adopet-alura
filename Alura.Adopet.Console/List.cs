using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Alura.Adopet.Console
{
    internal class List
    {
        // cria instância de HttpClient para consumir API Adopet
        HttpClient client;
        public List()
        {
            client = ConfiguraHttpClient("http://localhost:5057");
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

        HttpClient ConfiguraHttpClient(string url)
        {
            HttpClient _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            _client.BaseAddress = new Uri(url);
            return _client;
        }
    }
}
