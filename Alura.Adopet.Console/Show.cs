namespace Alura.Adopet.Console
{
    internal class Show:IComando
    {
        public string CaminhoDoArquivo { get; }
        public string Documentacao => "adopet show  <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.";

        public Show(string caminhoDoArquivo)
        {
            CaminhoDoArquivo = caminhoDoArquivo;
        }

        public async Task Executar()
        {
            LeitorDeArquivos leitor = new();
            List<Pet> listaDePet = leitor.RealizaLeituraArquivo(CaminhoDoArquivo);
            foreach (Pet pet in listaDePet)
            {
                System.Console.WriteLine(pet);
            }
            System.Console.ReadKey();
        }

    }
}
