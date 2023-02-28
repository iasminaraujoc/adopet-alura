using System.Net.Http.Json;
using Alura.Adopet.Console.ClienteHTTP;
using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Comandos
{
    internal class Import : IComando
    {
        public string Argumento { get; set; }
        public async Task RealizaImportacaoAsync(string caminhoArquivo)
        {
            List<Pet> listaDePet = new List<Pet>();

            using (StreamReader sr = new StreamReader(caminhoArquivo))
            {
                while (!sr.EndOfStream)
                {
                    string[] propriedades = sr.ReadLine().Split(';');
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
        }

        Task<HttpResponseMessage> CreatePetAsync(Pet pet)
        {
            HttpResponseMessage? response = null;
            using (response = new HttpResponseMessage())
            {
                return new Cliente().GetClient().PostAsJsonAsync("pet/add", pet);
            }
        }

        public async Task ExecutarAsync()
        {
            await RealizaImportacaoAsync(Argumento);
        }

        public string DocumentacaoComando()
        {
            return $" adopet import <arquivo> " +
                    "comando que realiza a importação do arquivo de pets.";
        }
    }
}
