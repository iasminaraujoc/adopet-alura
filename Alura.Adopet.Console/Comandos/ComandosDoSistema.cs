using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Comandos
{
    internal class ComandosDoSistema : IEnumerable<IComando>
    {
        private static ComandosDoSistema _comandos;
        public static ComandosDoSistema COMANDOS
        {
            get
            {
                if (_comandos is null) _comandos = new();
                return _comandos;
            }
        }

        // comandos que o sistema suporta (funções do sistema)
        private Dictionary<string, IComando> comandos = new()
        {
            { "import", new Import() },
            { "show", new Show() },
            { "list", new List() },
            { "help", new Help() },
        };

        public IComando? this[string key] => comandos[key];

        public IEnumerator<IComando> GetEnumerator()
        {
            return comandos.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
