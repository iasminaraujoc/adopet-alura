using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Console.Comandos
{
    internal class Show
    {
        public void ExibeArquivos(string caminhoArquivo)
        {
            LeitorDeArquivos leitor = new();
            List<Pet> listaDePet = leitor.RealizaLeituraArquivo(caminhoArquivo);
            foreach (Pet pet in listaDePet)
            {
                System.Console.WriteLine(pet);
            }
            System.Console.ReadKey();
        }

    }
}
