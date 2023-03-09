using Alura.Adopet.Console.UI;

namespace Alura.Adopet.Console.Comandos
{
    internal class Help : IComando
    {
        public string Documentacao => $" adopet help [comando] para obter mais informações sobre um comando.";

        public Task ExecutarAsync(string[] args)
        {
            if (args.Length == 2) this.HelpDoComando(comando: args[1]);
            else this.ExibeDocumentacao();
            return Task.CompletedTask;
        }

        public void ExibeDocumentacao()
        {
            InterfaceComUsuario.ExibeInformacao("Lista de comandos.");
            // se não passou mais nenhum argumento mostra help de todos os comandos
            InterfaceComUsuario.ExibeInformacao("adopet help <parametro> ous simplemente adopet help  " +
                    "comando que exibe informações de ajuda dos comandos.");
            InterfaceComUsuario.ExibeInformacao("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
            InterfaceComUsuario.ExibeInformacao("Realiza a importação em lote de um arquivos de pets.");
            System.Console.WriteLine("Comando possíveis: ");
            foreach (var cmd in ComandosDoSistema.COMANDOS)
            {
                InterfaceComUsuario.ExibeInformacao(cmd.Documentacao);
            }            
        }
        public void HelpDoComando(string comando)
        {
            var cmd = ComandosDoSistema.COMANDOS[comando];
            if (cmd is not null)
                InterfaceComUsuario.ExibeInformacao(cmd.Documentacao);
        }
    }
}
