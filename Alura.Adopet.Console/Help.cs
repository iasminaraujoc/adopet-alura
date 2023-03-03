namespace Alura.Adopet.Console
{
    internal class Help: IComandoAsync
    {
        public string Documentacao => " adopet help [comando] para obter mais informações sobre um comando.";

        public Task ExecutarAsync(string[] args)
        {
            var cmds = new ComandosDoSistema();

            if (args.Length == 2)
            {
                string chaveComando = args[1];
                var comando = cmds[chaveComando];
                if (comando is not null) System.Console.WriteLine(comando.Documentacao);
                return Task.CompletedTask;
            }
            System.Console.WriteLine("Lista de comandos.");
            // se não passou mais nenhum argumento mostra help de todos os comandos
            System.Console.WriteLine("adopet help <parametro> ous simplemente adopet help  " +
                    "comando que exibe informações de ajuda dos comandos.");
            System.Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
            System.Console.WriteLine("Realiza a importação em lote de um arquivos de pets.");
            System.Console.WriteLine("Comando possíveis: ");
            foreach (var comando in cmds.Values)
            {
                System.Console.WriteLine(comando.Documentacao);
            }

            return Task.CompletedTask;
        }

       
    }
}
