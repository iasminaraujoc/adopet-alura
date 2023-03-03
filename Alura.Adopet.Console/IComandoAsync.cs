namespace Alura.Adopet.Console
{
    internal interface IComandoAsync
    {
        public string Documentacao { get;}
        public Task ExecutarAsync();
    }
}
