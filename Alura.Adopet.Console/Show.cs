using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console
{
    internal class Show
    {
        public void MostrarArquivo(string caminhoArquivo)
        {
            LeitorDeArquivo leitor = new LeitorDeArquivo();
            List<Pet> listaDePet = leitor.RealizaLeituraArquivo(caminhoArquivo);
        }
    }
}
