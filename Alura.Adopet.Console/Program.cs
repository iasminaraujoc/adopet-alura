using Alura.Adopet.Console;

var comandos = new ComandosDoSistema();
Console.ForegroundColor = ConsoleColor.Green;
try
{
    if (args.Length > 0)
    {
        var comando = comandos[args[0]];
        await comando.ExecutarAsync(args);
    }
    else Console.WriteLine("Comando inválido!"); 
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
