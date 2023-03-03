namespace Alura.Adopet.Console
{
    internal class Show: IComandoAsync
    {
        public string Documentacao => " adopet show  <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.";
              
        public Task ExecutarAsync(string[] args)
        {
            var caminhoArquivo = args[1];
            LeitorDeArquivos leitor = new();
            List<Pet> listaDePet = leitor.RealizaLeituraArquivo(caminhoArquivo);
            foreach (Pet pet in listaDePet)
            {
                System.Console.WriteLine(pet);
            }

            return Task.CompletedTask;            
        }
    }
}
