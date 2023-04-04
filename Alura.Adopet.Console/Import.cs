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
        public async Task ImportarPetsAsync(string caminhoArquivo)
        {
            LeitorDeArquivo leitor = new LeitorDeArquivo();
            List<Pet> listaDePet = leitor.RealizaLeituraArquivo(caminhoArquivo);    
            
            foreach (var pet in listaDePet)
            {
                try
                {
                    var clientPet = new PetService();
                    await clientPet.CreatePetAsync(pet);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            System.Console.WriteLine("Importação concluída!");
        }
        
    }
}
