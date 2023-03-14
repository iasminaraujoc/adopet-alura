namespace Alura.Adopet.Console.Comandos
{
    internal class Ok: IResultado
    {
        public Ok(object informacao)
        {
            Informacao = informacao;
        }

        public bool Sucesso => true;
        public object Informacao { get; }
    }
}
