using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.UI
{
    internal class ExibicaoListaPets : IExibicao<List<Pet>>
    {
        public void Exibe(List<Pet> resultado)
        {
            foreach (var item in resultado)
            {
                System.Console.WriteLine(item);
            }            
        }
    }
}
