using Alura.Adopet.Console.Comandos;

namespace Alura.Adopet.Console.UI
{
    internal class ExibicaoListaStrings : Exibicao
    {
        public ExibicaoListaStrings(Exibicao? proximo) : base(proximo) { }

        public override bool PodeExibir(Ok resultado)
        {
            return resultado.Informacao is List<string>;
        }

        public override void Exibe(Ok resultado)
        {
            if (this.PodeExibir(resultado))
            {
                List<string> strings = (List<string>)resultado.Informacao;
                foreach (var item in strings)
                {
                    System.Console.WriteLine(item);
                }
            }
            else base.Exibe(resultado);
        }
    }
}
