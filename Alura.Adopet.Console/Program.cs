using Alura.Adopet.Console;

Console.ForegroundColor = ConsoleColor.Green;
try
{
    // args[0] é o comando a ser executado pelo programa

    switch (args[0].Trim())
    {
        case "import":
            var import = new Import(caminhoArquivo: args[1]);
            await import.Executar();            
            break;
        case "help":
            Help help;
            if (args.Length == 2)       
            {
                help = new Help(comando: args[1]);
                help.Executar();
            }     
            else
            {
                help = new Help();
                help.ExibeDocumentacao();
            }
            break;
        case "show":
            var show = new Show(caminhoDoArquivo: args[1]);
            show.Executar();    
            break;
        case "list":
            var list = new List();
            await list.Executar();            
            break;
        default:
            // exibe mensagem de comando inválido
            Console.WriteLine("Comando inválido!");
            break;
    }
}
catch (Exception ex)
{
    // mostra a exceção em vermelho
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Aconteceu um exceção: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.White;
}
