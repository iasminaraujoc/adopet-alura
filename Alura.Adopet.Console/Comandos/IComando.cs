using Microsoft.AspNetCore.Mvc;

namespace Alura.Adopet.Console.Comandos
{
    internal interface IComando // padrão Command
    {
        string Documentacao { get; }
        Task<ActionResult<IEnumerable<string>>> ExecutarAsync(string[] args);
    }
}
