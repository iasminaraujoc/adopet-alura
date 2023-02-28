using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Comandos
{
    internal class Show : IComando
    {
        public string Argumento { get; set; }

        public string DocumentacaoComando()
        {
            return $" adopet show <arquivo>  comando que " +
                    "exibe no terminal o conteúdo do arquivo importado.";
        }

        public async Task ExecutarAsync()
        {
            ExibeArquivo(Argumento);
        }

        public void ExibeArquivo(string caminhoArquivo)
        {
            using (StreamReader sr = new StreamReader(caminhoArquivo))
            {
                System.Console.WriteLine("----- Importaddos os dados abaixo -----");
                while (!sr.EndOfStream)
                {
                    string[] propriedades = sr.ReadLine().Split(';');
                    Pet pet = new Pet(Guid.Parse(propriedades[0]),
                    propriedades[1],
                    TipoPet.Cachorro
                    );
                    System.Console.WriteLine(pet);
                }
            }

        }

    }
}
