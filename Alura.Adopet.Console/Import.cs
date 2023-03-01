using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console
{
    internal class Import
    {
        // cria instância de HttpClient para consumir API Adopet
        HttpClient client;
        public Import()
        {
            client = ConfiguraHttpClient("http://localhost:5057");
        }
        public async Task RealizaImportacaoAsync(string caminhoArquivo)
        {
            List<Pet> listaDePet = new List<Pet>();

            // args[1] é o caminho do arquivo a ser importado
            using (StreamReader sr = new StreamReader(caminhoArquivo))
            {
                while (!sr.EndOfStream)
                {
                    // separa linha usando ponto e vírgula
                    string[] propriedades = sr.ReadLine().Split(';');
                    // cria objeto Pet a partir da separação
                    Pet pet = new Pet(Guid.Parse(propriedades[0]),
                      propriedades[1],
                      TipoPet.Cachorro
                     );

                    System.Console.WriteLine(pet);
                    listaDePet.Add(pet);
                }
            }
            foreach (var pet in listaDePet)
            {
                try
                {
                    var resposta = await CreatePetAsync(pet);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            System.Console.WriteLine("Importação concluída!");
            System.Console.ReadKey();
        }

        Task<HttpResponseMessage> CreatePetAsync(Pet pet)
        {
            HttpResponseMessage? response = null;
            using (response = new HttpResponseMessage())
            {
                return client.PostAsJsonAsync("pet/add", pet);
            }
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
