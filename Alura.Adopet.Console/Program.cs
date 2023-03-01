using Alura.Adopet.Console;

Console.ForegroundColor = ConsoleColor.Green;
try
{
    string comando = args[0];

    switch (comando.Trim())
    {
        case "import":
            var import = new Import();
            await import.RealizaImportacaoAsync(caminhoArquivo:args[1]);
            break;
        case "help":
            var help = new Help();
            if (args.Length == 2) 
            {
                help.HelpDoComando(docComando: args[1]);
            }
            else
            {
                help.ExibeDocumentacao();
            }
            break;
        case "show":
            var show = new Show();
            show.ExibeArquivo(caminhoArquivo:args[1]);
            break;
        default:
            Console.WriteLine("Comando inválido!");
            break;
    }
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Aconteceu um exceção: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.White;
}
