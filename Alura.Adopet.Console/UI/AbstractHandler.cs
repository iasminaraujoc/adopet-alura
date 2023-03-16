using Alura.Adopet.Console.Comandos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.UI
{
    abstract class AbstractHandler : IHandler
    {
        public AbstractHandler? Proximo { get; }

        public AbstractHandler(AbstractHandler? handler)
        {
            Proximo = handler;
        }
        public virtual void SetNextHandler(Ok resultado)
        {
            if (Proximo is not null)
            {
                Proximo.SetNextHandler(resultado);
            }
        }
        public abstract bool ValidaHandler(Ok resultado);

    }
}
