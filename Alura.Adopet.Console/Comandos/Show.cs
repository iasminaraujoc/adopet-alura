using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Console.Comandos
{
    [DocumentacaoDoComando($" adopet show   <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.")]
    internal class Show : IComando
    {
        public Task ExecutarAsync(string[] args)
        {
            this.ExibeArquivos(caminhoArquivo: args[1]);
            return Task.CompletedTask;
        }

        public void ExibeArquivos(string caminhoArquivo)
        {
            LeitorDeArquivos leitor = new();
            List<Pet> listaDePet = leitor.RealizaLeituraArquivo(caminhoArquivo);
            foreach (Pet pet in listaDePet)
            {
                System.Console.WriteLine(pet);
            }
            System.Console.ReadKey();
        }

    }
}
