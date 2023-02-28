using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.ClienteHTTP
{
    internal class Cliente
    {
        private readonly HttpClient client;

        public HttpClient GetClient() { return client; }
        public Cliente()
        {
            client = ConfiguraHttpClient("https://localhost:7136");
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
