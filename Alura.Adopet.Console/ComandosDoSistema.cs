using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console
{
    internal class ComandosDoSistema : IReadOnlyDictionary<string, IComandoAsync>
    {
        private readonly Dictionary<string, IComandoAsync> comandos = new()
        {
            { "import", new Import() },
            { "help", new Help() },
            { "show", new Show() },
            { "list", new List() }
        };

        public IComandoAsync this[string key] => comandos[key];

        public IEnumerable<string> Keys => comandos.Keys;

        public IEnumerable<IComandoAsync> Values => comandos.Values;

        public int Count => comandos.Count;

        public bool ContainsKey(string key) => comandos.Keys.Contains(key);

        public IEnumerator<KeyValuePair<string, IComandoAsync>> GetEnumerator()
        {
            return comandos.GetEnumerator();
        }

        public bool TryGetValue(string key, [MaybeNullWhen(false)] out IComandoAsync value)
        {
            return comandos.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return comandos.GetEnumerator();
        }
    }
}
