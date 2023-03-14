using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.UI;

var instrucao = args[0]; 
var comando = ComandosDoSistema.COMANDOS[instrucao];
if (comando is not null)
{
    IResultado resultado = await comando.ExecutarAsync(args);
    if (resultado.Sucesso) InterfaceComUsuario.ExibeInformacao(resultado as Ok);
    else InterfaceComUsuario.ExibeErro(resultado as Erro);
}
else InterfaceComUsuario.ExibeInformacao("Comando inválido");