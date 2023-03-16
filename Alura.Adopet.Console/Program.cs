using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.UI;

var instrucao = args[0];
var comando = ComandosDoSistema.COMANDOS[instrucao];
if (comando is not null)
{
    IResultado resultado = await comando.ExecutarAsync(args);
    InterfaceComUsuario.ExibeResultado(resultado);
}
else InterfaceComUsuario.ExibeInformacao("Comando inválido");

