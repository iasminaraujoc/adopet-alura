namespace Alura.Adopet.Console.Comandos
{
    internal class Help : IComando
    {
        public string Argumento { get; set; }

        public string DocumentacaoComando()
        {
            return $"Lista de comandos." +
            $"adopet help <parametro> ous simplemente adopet help  " +
                    "comando que exibe informações de ajuda dos comandos." +
            $"Adopet (1.0) - Aplicativo de linha de comando (CLI)." +
            $"Realiza a importação em lote de um arquivos de pets." +
            $"Comando possíveis: " +
            $" adopet import <arquivo> comando que realiza a importação do arquivo de pets." +
            $" adopet show  <arquivo> comando que exibe no terminal o conteúdo do arquivo importado." + "\n\n" +
            $"Execute 'adopet.exe help [comando]' para obter mais informações sobre um comando." + "\n\n\n";
        }

        public async Task ExecutarAsync()
        {
            if (string.IsNullOrEmpty(Argumento))
            {
                System.Console.WriteLine(DocumentacaoComando());
            }
            HelpDoComando(Argumento);
        }

        public void HelpDoComando(string docComando)
        {
            if (docComando.Equals("import"))
            {
                System.Console.WriteLine(new Import().DocumentacaoComando());
            }
            if (docComando.Equals("show"))
            {
                System.Console.WriteLine(new Show().DocumentacaoComando());
            }
        }

    }
}
