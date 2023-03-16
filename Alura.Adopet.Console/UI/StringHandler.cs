using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.UI
{
    internal class StringHandler : AbstractHandler
    {
        public StringHandler(AbstractHandler? handler) : base(handler)
        {
        }

        public override bool ValidaHandler(Ok resultado)
        {
            return (resultado.Informacao is string);
        }
        public override void SetNextHandler(Ok resultado)
        {
            if (this.ValidaHandler(resultado))
            {

                string mensagem = (string)resultado.Informacao;
                System.Console.WriteLine(mensagem);

            }
            else
            {
                base.SetNextHandler(resultado);
            }
        }

    }
}
