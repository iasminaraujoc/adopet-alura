﻿using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Alura.Adopet.Console
{
    internal class Import: IComandoAsync
    {
        // cria instância de HttpClient para consumir API Adopet
        HttpClient client;

        public Import()
        {
            client = ConfiguraHttpClient("http://localhost:5057");
        }
   
        public string Documentacao => " adopet import <arquivo> comando que realiza a importação do arquivo de pets.";

        public async Task RealizaImportacaoAsync(string caminhoArquivo)
        {
            LeitorDeArquivos leitor = new();
            List<Pet>  listaDePet = leitor.RealizaLeituraArquivo(caminhoArquivo);
            foreach (var pet in listaDePet)
            {
                System.Console.WriteLine(pet);
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

        public async Task ExecutarAsync(string[] args)
        {
           await RealizaImportacaoAsync(caminhoArquivo: args[1]);
        }
    }

}
