using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando($" adopet import <arquivo> comando que realiza a importação do arquivo de pets.")]
    internal class Import : Comando
    {
        PetService clientPet;
        public Import()
        {
            clientPet = new PetService();
        }

        public override async Task<IResultado> ExecAsync(string[] args)
        {
            string caminhoArquivo = args[1];
            LeitorDeArquivos leitor = new();
            List<Pet> listaDePet = leitor.RealizaLeituraArquivo(caminhoArquivo);
            foreach (var pet in listaDePet)
            {
                try
                {
                    await clientPet.CreatePetAsync(pet);
                }
                catch (Exception ex)
                {
                    return new Erro(ex.Message);
                }
            }
            return new Ok(listaDePet);
        }
    }
}
