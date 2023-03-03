namespace Alura.Adopet.Console
{
    internal interface IComandoAsync
    {
        string Documentacao { get; }
        Task ExecutarAsync(string[] args);
    }
}
