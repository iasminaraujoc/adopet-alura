using Alura.Adopet.Console.Comandos;

namespace Alura.Adopet.Console.UI
{
    internal class ExibicaoListaStrings : IExibicao<List<string>>
    {
        public void Exibe(List<string> resultado)
        {
            foreach (var item in resultado)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}
