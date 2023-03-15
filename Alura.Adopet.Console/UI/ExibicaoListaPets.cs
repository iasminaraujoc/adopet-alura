using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.UI
{
    internal class ExibicaoListaPets : Exibicao
    {
        public ExibicaoListaPets(Exibicao? proximo): base(proximo) { }

        public override bool PodeExibir(Ok resultado)
        {
            return resultado.Informacao is List<Pet>;
        }

        public override void Exibe(Ok resultado)
        {
            if (this.PodeExibir(resultado))
            {
                List<Pet> lista = (List<Pet>)resultado.Informacao;
                foreach (var item in lista)
                {
                    System.Console.WriteLine(item);
                }
            } else base.Exibe(resultado);
            
        }
    }
}
