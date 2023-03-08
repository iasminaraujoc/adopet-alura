using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Comandos
{
    [AttributeUsage(AttributeTargets.Field)]
    public class DocAttributes:Attribute
    {
        public string Documentacao { get; }
        private Dictionary<string, string> comandos = new Dictionary<string, string>()
        {
            { "import",$" adopet import <arquivo> comando que realiza a importação do arquivo de pets." },
            { "show",$" adopet show   <arquivo> comando que exibe no terminal o conteúdo do arquivo importado." },
            { "list",$" adopet list  comando que exibe no terminal o conteúdo importado no servidor." },
            { "help",$" adopet help [comando] para obter mais informações sobre um comando." },
        };

        public DocAttributes(string documentacao)
        {
            Documentacao = comandos[documentacao];
        }
      
    }
}
