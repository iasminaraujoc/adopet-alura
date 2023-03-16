using Alura.Adopet.Console.Comandos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.UI
{
    internal interface IHandler
    {
        void SetNextHandler(Ok resultado);
    }
}
