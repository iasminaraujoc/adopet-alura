using System.Net.Http.Headers;

namespace Alura.Adopet.Console
{
    internal class HttpClientPet
    {
        private HttpClient client;
        public HttpClientPet()
        {
            client = ConfiguraHttpClient("http://localhost:5057");
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

        public HttpClient GetHttpClient()
        {
            return client;
        }
    }
}
