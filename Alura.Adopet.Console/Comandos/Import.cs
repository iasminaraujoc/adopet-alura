using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.UI;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Console.Comandos
{
    internal class Import : IComando
    {
        PetService clientPet;
        public Import()
        {
            clientPet = new PetService();
        }

        public string Documentacao => $" adopet import <arquivo> comando que realiza a importação do arquivo de pets.";

        public async Task ExecutarAsync(string[] args)
        {
            await RealizaImportacaoAsync(caminhoArquivo: args[1]);
        }

        public async Task RealizaImportacaoAsync(string caminhoArquivo)
        {

            // args[1] é o caminho do arquivo a ser importado
            LeitorDeArquivos leitor = new();
            List<Pet> listaDePet = leitor.RealizaLeituraArquivo(caminhoArquivo);
            foreach (var pet in listaDePet)
            {
                InterfaceComUsuario.ExibeInformacao(pet.ToString());
                try
                {
                    await clientPet.CreatePetAsync(pet);
                }
                catch (Exception ex)
                {
                    InterfaceComUsuario.ExibeInformacao(ex.Message);
                }
            }
            InterfaceComUsuario.ExibeInformacao("Importação concluída!");           
        }

    }

}
