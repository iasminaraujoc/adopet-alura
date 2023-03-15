using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;
using System.Runtime.CompilerServices;

namespace Alura.Adopet.Console.UI
{
    internal static class InterfaceComUsuario
    {
        public static void ExibeInformacao(string mensagem)
        {
            ExibeResultado(new Ok(mensagem));
        }

        public static void ExibeResultado(IResultado resultado)
        {
            if (resultado is null) return;

            var defaultColor = System.Console.ForegroundColor;
            try
            {
                if (resultado is Ok) ExibeInformacao(resultado as Ok);
                else ExibeErro(resultado as Erro);
            }
            finally
            {
                System.Console.ForegroundColor = defaultColor;
            }
        }

        private static void ExibeInformacao(Ok? resultado)
        {
            if (resultado is null) return;
            if (resultado.Informacao is null) return;

            System.Console.ForegroundColor = ConsoleColor.Green;
            MotorExibicao.ExibeInformacao(resultado);
        }

        private static void ExibeErro(Erro? resultado)
        {
            if (resultado is null) return;
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine($"Aconteceu um exceção: {resultado.MensagemErro}");
        }
    }
}
