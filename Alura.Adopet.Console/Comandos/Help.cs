using Alura.Adopet.Console.UI;
using Microsoft.AspNetCore.Mvc;

namespace Alura.Adopet.Console.Comandos
{
    internal class Help : IComando
    {
        public string Documentacao => $" adopet help [comando] para obter mais informações sobre um comando.";

        public Task<ActionResult<IEnumerable<string>>> ExecutarAsync(string[] args)
        {
            var retorno = new List<string>();
            if (args.Length == 2) retorno = this.HelpDoComando(comando: args[1]);
            else retorno = this.ExibeDocumentacao();    
            return Task.FromResult<ActionResult<IEnumerable<string>>>(retorno);
        }

        private List<string> ExibeDocumentacao()
        {
            var retorno = new List<string>();
            retorno.Add("Lista de comandos.");
            // se não passou mais nenhum argumento mostra help de todos os comandos
            retorno.Add("adopet help <parametro> ous simplemente adopet help  " +
                    "comando que exibe informações de ajuda dos comandos.");
            retorno.Add("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
            retorno.Add("Realiza a importação em lote de um arquivos de pets.");
            retorno.Add("Comando possíveis: ");
            foreach (var cmd in ComandosDoSistema.COMANDOS)
            {
                retorno.Add(cmd.Documentacao);
            }     
            
            return retorno;
        }
        private List<string> HelpDoComando(string comando)
        {
            var retorno = new List<string>();
            var cmd = ComandosDoSistema.COMANDOS[comando];
            if (cmd is not null)
                retorno.Add(cmd.Documentacao);

            return retorno;
        }
    }
}
