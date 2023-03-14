using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando($" adopet show   <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.")]
    internal class Show : Comando
    {
        public override Task<IResultado> ExecAsync(string[] args)
        {
            try
            {
                var retorno = this.ExibeArquivos(caminhoArquivo: args[1]);
                return Task.FromResult<IResultado>(new Ok(retorno));
            }
            catch (Exception ex)
            {
                return Task.FromResult<IResultado>(new Erro(ex.Message));
            }
        }

        public List<Pet> ExibeArquivos(string caminhoArquivo)
        {
            LeitorDeArquivos leitor = new();
            List<Pet> listaDePet = leitor.RealizaLeituraArquivo(caminhoArquivo);
            return listaDePet;
        }

    }
}
