using Alura.Adopet.Console;
using Alura.Adopet.Console.Comandos;

Console.ForegroundColor = ConsoleColor.Green;
try
{
    // args[0] é o comando a ser executado pelo programa

    switch (args[0].Trim())
    {
        case "import":
            var import = new Import();
            await import.RealizaImportacaoAsync(caminhoArquivo: args[1]);            
            break;
        case "help":
            var help = new Help();
            if (args.Length == 2)       
            {
                help.HelpDoComando(comando: args[1]);
            }     
            else
            {
                help.ExibeDocumentacao();
            }
            break;
        case "show":
            var show = new Show();
            show.ExibeArquivos(caminhoArquivo: args[1]);    
            break;
        case "list":
            var list = new List();
            await list.ListPets();            
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
