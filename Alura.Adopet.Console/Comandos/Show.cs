using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.UI;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Console.Comandos
{
    internal class Show : IComando
    {
        public string Documentacao => $" adopet show   <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.";

        public Task<IResultado> ExecutarAsync(string[] args)
        {
            var retorno = this.ExibeArquivos(caminhoArquivo: args[1]);
            return Task.FromResult<IResultado>(new Ok(retorno));
        }

        public List<Pet> ExibeArquivos(string caminhoArquivo)
        {
            LeitorDeArquivos leitor = new();
            List<Pet> listaDePet = leitor.RealizaLeituraArquivo(caminhoArquivo);
            return listaDePet;
        }

    }
}
