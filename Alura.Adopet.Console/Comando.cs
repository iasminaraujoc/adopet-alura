using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console
{
    internal interface IComando
    {
        string Documentacao { get; }
        void Executar();        
    }
}
