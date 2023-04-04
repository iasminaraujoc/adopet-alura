using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console
{
    internal class PetService
    {
        HttpClient client;

        public PetService()
        {
            client = ConfiguraHttpClient("http://localhost:5057");
        }
        public Task CreatePetAsync(Pet pet)
        {  
            return client.PostAsJsonAsync("pet/add", pet);       
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
