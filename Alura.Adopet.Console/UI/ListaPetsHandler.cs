using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.UI
{
    internal class ListaPetsHandler : AbstractHandler
    {
        public ListaPetsHandler(AbstractHandler? handler) : base(handler)
        {
        }

        public override bool ValidaHandler(Ok resultado)
        {
            return resultado.Informacao is List<Pet>;
        }

        public override void SetNextHandler(Ok resultado)
        {
            if (this.ValidaHandler(resultado))
            {
                List<Pet> lista = (List<Pet>)resultado.Informacao;
                foreach (var item in lista)
                {
                    System.Console.WriteLine(item);
                }
            }
            else
            {
                base.SetNextHandler(resultado);
            }
        }
    }
}
