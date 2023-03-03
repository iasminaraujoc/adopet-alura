﻿using Alura.Adopet.Console;

Console.ForegroundColor = ConsoleColor.Green;
try
{
    // args[0] é o comando a ser executado pelo programa
    switch (args[0].Trim())
    {
        case "import":
            var import = new Import(caminhoDoArquivo: args[1]);
            await import.ExecutarAsync();            
            break;
        case "help":           
           
            if (args.Length == 2)       
            {
                var help = new Help(comando: args[1]);
                await help.ExecutarAsync();
            }     
            else
            {
                var help = new Help(null);
                await help.ExecutarAsync();
            }
            break;
        case "show":
            var show = new Show(caminhoDoArquivo: args[1]);
            await show.ExecutarAsync();    
            break;
        case "list":
            var list = new List();
            await list.ExecutarAsync();           
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
