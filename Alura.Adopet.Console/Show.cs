namespace Alura.Adopet.Console
{
    internal class Show
    {
        public void ExibeArquivo(string caminhoArquivo)
        {
            LeitorDeArquivo leitor = new();
            List<Pet> listaDePet = leitor.RealizaLeitura(caminhoArquivo);
            
            foreach(var pet in listaDePet)
            {
                System.Console.WriteLine(pet);
            }
           
        }

    }
}
