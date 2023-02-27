using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console
{
    internal class Show
    {
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
