using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Util
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    internal class DocumentacaoDoComando : Attribute
    {
        public DocumentacaoDoComando(string texto)
        {
            Texto = texto;
        }

        public string Texto { get; }
    }
}
