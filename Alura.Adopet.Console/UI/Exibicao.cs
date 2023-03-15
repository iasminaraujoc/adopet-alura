using Alura.Adopet.Console.Comandos;

namespace Alura.Adopet.Console.UI
{
    internal abstract class Exibicao
    {
        protected Exibicao(Exibicao? proximo)
        {
            Proximo = proximo;
        }

        public virtual void Exibe(Ok resultado)
        {
            if (Proximo is not null)
            {
                Proximo.Exibe(resultado);
            }
        }
        public abstract bool PodeExibir(Ok resultado);

        public Exibicao? Proximo { get; }
    }
}
