using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.UI
{
    internal static class InterfaceComUsuario
    {
        static public void ExibeInformacao(string mensagem)
        {
            System.Console.WriteLine(mensagem);
        }

        private static void ExibeLista<T>(List<T>? lista)
        {
            if (lista is null) return;
            foreach (var item in lista) 
            {
                System.Console.WriteLine(item);
            }
        }

        static public void ExibeInformacao(Ok resultado)
        {
            if (resultado is null) return;
            if (resultado.Informacao is null) return;

            if (resultado.Informacao is List<Pet>)
            {
                ExibeLista(resultado.Informacao as List<Pet>);
                return;
            }

            if(resultado.Informacao is List<string>)
            {
                ExibeLista(resultado.Informacao as List<string>);
                return;
            }

            System.Console.WriteLine(resultado.Informacao.ToString());
        }

        static public void ExibeErro(Erro resultado)
        {
            System.Console.WriteLine(resultado.MensagemErro);
        }
    }
}
