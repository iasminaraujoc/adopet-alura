using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Console.Comandos
{
    internal class Import
    {
        PetService clientPet;
        public Import()
        {
            clientPet = new PetService();
        }

        public async Task RealizaImportacaoAsync(string caminhoArquivo)
        {

            // args[1] é o caminho do arquivo a ser importado
            LeitorDeArquivos leitor = new();
            List<Pet> listaDePet = leitor.RealizaLeituraArquivo(caminhoArquivo);
            foreach (var pet in listaDePet)
            {
                System.Console.WriteLine(pet);
                try
                {
                    await clientPet.CreatePetAsync(pet);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            System.Console.WriteLine("Importação concluída!");
            System.Console.ReadKey();
        }

    }

}
