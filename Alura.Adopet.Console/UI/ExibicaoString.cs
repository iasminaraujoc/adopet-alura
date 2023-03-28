namespace Alura.Adopet.Console.UI
{
    internal class ExibicaoString : IExibicao<string>
    {
        public void Exibe(string resultado)
        {
            System.Console.WriteLine(resultado);
        }
    }
}
