namespace Alura.Adopet.Console
{
    internal class Help: IComandoAsync
    {
        private string? Comando { get; }
        public Help(string? comando)
        {
            this.Comando = comando;
        }
        private Dictionary<string, string> comandos = new Dictionary<string, string>()
        {
            { "import",$" adopet import <arquivo> comando que realiza a importação do arquivo de pets." },
            { "show",$" adopet show   <arquivo> comando que exibe no terminal o conteúdo do arquivo importado." },
            { "list",$" adopet list  comando que exibe no terminal o conteúdo importado no servidor." },
            { "help",$" adopet help [comando] para obter mais informações sobre um comando." },
        };

        public string Documentacao => comandos["help"];     

        public Task ExecutarAsync()
        {
            if (!string.IsNullOrEmpty(Comando))
            {
                var documentacaoComando = comandos[Comando];
                System.Console.WriteLine(documentacaoComando);
                return Task.CompletedTask;
            }
            System.Console.WriteLine("Lista de comandos.");
            // se não passou mais nenhum argumento mostra help de todos os comandos
            System.Console.WriteLine("adopet help <parametro> ous simplemente adopet help  " +
                    "comando que exibe informações de ajuda dos comandos.");
            System.Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
            System.Console.WriteLine("Realiza a importação em lote de um arquivos de pets.");
            System.Console.WriteLine("Comando possíveis: ");
            foreach (var comando in comandos)
            {
                System.Console.WriteLine(comando.Value);
            }

            return Task.CompletedTask;
        }

       
    }
}
