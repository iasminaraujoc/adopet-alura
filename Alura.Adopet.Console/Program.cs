using Alura.Adopet.Console.Comandos;

Console.ForegroundColor = ConsoleColor.Green;
try
{
    var instrucao = args[0]; 
    var comando = ComandosDoSistema.COMANDOS[instrucao];
    if (comando is not null) await comando.ExecutarAsync(args);
    else Console.WriteLine("Comando inválido");
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
