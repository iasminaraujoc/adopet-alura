using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Util
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class DocComando : System.Attribute
    {
        public DocComando(string documentacao)
        {
            Documentacao = documentacao;
        }

        public string Documentacao { get; }
    }
}
