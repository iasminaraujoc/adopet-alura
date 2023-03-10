using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.UI;

Console.ForegroundColor = ConsoleColor.Green;
try
{
    var instrucao = args[0]; 
    var comando = ComandosDoSistema.COMANDOS[instrucao];
    if (comando is not null)
    {
      var resultado = await comando.ExecutarAsync(args);
      InterfaceComUsuario.ExibeInformacao(resultado);
    }
    else InterfaceComUsuario.ExibeInformacao("Comando inválido");
}
catch (Exception ex)
{
    // mostra a exceção em vermelho
    Console.ForegroundColor = ConsoleColor.Red;
    InterfaceComUsuario.ExibeInformacao($"Aconteceu um exceção: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.White;
}
