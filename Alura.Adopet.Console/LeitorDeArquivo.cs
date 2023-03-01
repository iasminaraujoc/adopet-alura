namespace Alura.Adopet.Console
{
    /// <summary>
    /// Lê um arquivo texto e transforma/converte/cria uma lista de pets.
    /// </summary>
    internal class LeitorDeArquivo
    {
        public List<Pet> RealizaLeitura(string caminhoArquivo)
        {
            List<Pet> lista = new();
            using (StreamReader sr = new StreamReader(caminhoArquivo))
            {
                while (!sr.EndOfStream)
                {
                    string[] propriedades = sr.ReadLine().Split(';');
                    Pet pet = new Pet(Guid.Parse(propriedades[0]),
                      propriedades[1],
                      TipoPet.Cachorro
                     );

                    lista.Add(pet);
                }
            }
            return lista;
        }
    }
}
