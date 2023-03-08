using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Comandos
{
    internal interface IComando // padrão Command
    {
        //string Documentacao { get; }
        Task ExecutarAsync(string[] args);
    }
}
