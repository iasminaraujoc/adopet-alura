using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Util;
using Microsoft.AspNetCore.Mvc;

namespace Alura.Adopet.Console.Comandos
{
    internal class Show : IComando
    {
        public string Documentacao => $" adopet show   <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.";

        public Task<ActionResult<IEnumerable<string>>> ExecutarAsync(string[] args)
        {
            var retorno = this.ExibeArquivos(caminhoArquivo: args[1]);         
            return Task.FromResult<ActionResult<IEnumerable<string>>>(retorno);

        }

        public List<string> ExibeArquivos(string caminhoArquivo)
        {
            var retorno = new List<string>();
            LeitorDeArquivos leitor = new();
            List<Pet> listaDePet = leitor.RealizaLeituraArquivo(caminhoArquivo);
            foreach (Pet pet in listaDePet)
            {
               retorno.Add(pet.ToString());
            }
            return retorno;
        }

    }
}
