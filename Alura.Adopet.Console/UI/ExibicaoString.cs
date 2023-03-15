using Alura.Adopet.Console.Comandos;

namespace Alura.Adopet.Console.UI
{
    internal class ExibicaoString : Exibicao
    {
        public ExibicaoString(Exibicao? proximo) : base(proximo)
        {
        }

        public override bool PodeExibir(Ok resultado)
        {
            return (resultado.Informacao is string);
        }

        public override void Exibe(Ok resultado)
        {
            if (this.PodeExibir(resultado))
            {
                string mensagem = (string)resultado.Informacao;
                System.Console.WriteLine(mensagem);
            }
            else base.Exibe(resultado);
        }
    }
}
