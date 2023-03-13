using Alura.Adopet.Console.Comandos;

namespace Alura.Adopet.Console.UI
{
    internal static class InterfaceComUsuario
    {
        static public void ExibeInformacao(string mensagem)
        {
            System.Console.WriteLine(mensagem);
        }

        static public void ExibeInformacao(Ok resultado)
        {
            System.Console.WriteLine(resultado.Informacao.ToString());
            //foreach (var mensagem in mensagems)
            //{
            //    System.Console.WriteLine(mensagem);
            //}
        }

        static public void ExibeErro(Erro resultado)
        {
            System.Console.WriteLine(resultado.MensagemErro);
        }
    }
}
