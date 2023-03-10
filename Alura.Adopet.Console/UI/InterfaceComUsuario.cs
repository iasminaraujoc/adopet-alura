namespace Alura.Adopet.Console.UI
{
    internal static class InterfaceComUsuario
    {
        static public void ExibeInformacao(string mensagem)
        {
            System.Console.WriteLine(mensagem);
        }

        static public void ExibeInformacao(List<string> mensagems)
        {
            foreach (var mensagem in mensagems)
            {
                System.Console.WriteLine(mensagem);
            }
        }
    }
}
