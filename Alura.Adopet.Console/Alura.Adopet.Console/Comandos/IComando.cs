namespace Alura.Adopet.Console.Comandos
{
    internal interface IComando
    {
        public string Argumento { get; set; }
        public Task ExecutarAsync();
        public string DocumentacaoComando();
    }
}
