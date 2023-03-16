using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.UI
{
    internal static class InterfaceComUsuario
    {
        static public void ExibeInformacao(string mensagem)
        {
            ExibeResultado(new Ok(mensagem));
        }            
        private static void ExibeInformacao(Ok? resultado)
        {
            if (resultado is null) return;
            if (resultado.Informacao is null) return;

            System.Console.ForegroundColor = ConsoleColor.Green;
            ControllerHandler.ExibeInfoHandler(resultado);
        }

        private static void ExibeErro(Erro? resultado)
        {
            if (resultado is null) return;
            
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine(resultado.MensagemErro);            
        }

        public static void ExibeResultado(IResultado resultado)
        {
            try
            {
                if (resultado.Sucesso) ExibeInformacao(resultado as Ok);
                else ExibeErro(resultado as Erro);
            }
            finally
            {
                System.Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
