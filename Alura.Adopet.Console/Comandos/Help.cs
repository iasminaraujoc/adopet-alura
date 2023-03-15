using System.Reflection;

namespace Alura.Adopet.Console.Comandos
{
    [Util.DocComando($" adopet help [comando] para obter mais informações sobre um comando.")]
    internal class Help : Comando
    {
        public override Task<IResultado> ExecAsync(string[] args)
        {
            var retorno = new List<string>();
            if (args.Length == 2) retorno = this.HelpDoComando(comando: args[1]);
            else retorno = this.ExibeDocumentacao();

            return Task.FromResult<IResultado>(new Ok(retorno));
        }

        private string RecuperaDocumentacao(IComando comando)
        {
            Type tipoComando = comando.GetType();
            var doc = tipoComando.GetCustomAttributes<Util.DocComando>().FirstOrDefault();
            if (doc is not null) return doc.Documentacao;
            return string.Empty;
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
                retorno.Add(this.RecuperaDocumentacao(cmd));
            }     
            
            return retorno;
        }
        private List<string> HelpDoComando(string comando)
        {
            var retorno = new List<string>();
            var cmd = ComandosDoSistema.COMANDOS[comando];
            if (cmd is not null)
                retorno.Add(this.RecuperaDocumentacao(cmd));

            return retorno;
        }
    }
}
