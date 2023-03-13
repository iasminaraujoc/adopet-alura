namespace Alura.Adopet.Console.Comandos
{
    internal class Erro : IResultado
    {
        public Erro(string mensagemErro)
        {
            MensagemErro = mensagemErro;
        }

        public bool Sucesso => false;
        public string MensagemErro { get; }
    }
}
