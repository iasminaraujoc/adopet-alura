using Alura.Adopet.Console.Modelos;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Alura.Adopet.Console.Services
{
    internal class PetService
    {
        private HttpClient client;

        public PetService()
        {
            client = ConfiguraHttpClient("http://localhost:5056");
        }

        private HttpClient ConfiguraHttpClient(string url)
        {
            HttpClient _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            _client.BaseAddress = new Uri(url);
            return _client;
        }

        private HttpClient GetHttpClient()
        {
            return client;
        }

        private async Task<IEnumerable<Pet>?> ListPetsAsync()
        {
            HttpResponseMessage response = await client.GetAsync("pet/list");
            return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
        }

        public async Task<IEnumerable<Pet>?> ListAsync()
        {
            // cliente
            var cliente = GetHttpClient();
            // chama o endpoint
            return await ListPetsAsync();
            //return lista
        }

        private Task<HttpResponseMessage> PostAsync(Pet pet)
        {
            HttpResponseMessage? response = null;
            using (response = new HttpResponseMessage())
            {
                return client.PostAsJsonAsync("pet/add", pet);
            }
        }

        public async Task CreatePetAsync(Pet pet)
        {
            await PostAsync(pet);
        }
    }
}
