using Alura.Adopet.Console.Comandos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.UI
{
    internal static class ControllerHandler
    {
        public static void ExibeInfoHandler(Ok ok)
        {
            StringHandler _stringHandler = new(null);
            ListaStringHandler _listaStringHandler = new(_stringHandler);
            ListaPetsHandler _listaPetsHandler = new(_listaStringHandler);

            AbstractHandler _handler = _listaPetsHandler;
            _handler.SetNextHandler(ok);

        }
    }
}
