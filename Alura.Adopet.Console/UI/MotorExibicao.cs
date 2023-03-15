using Alura.Adopet.Console.Comandos;

namespace Alura.Adopet.Console.UI
{
    internal static class MotorExibicao
    {
        public static void ExibeInformacao(Ok resultado)
        {
            ExibicaoString uiString = new(null);
            ExibicaoListaStrings uiStrings = new(uiString);
            ExibicaoListaPets uiPets = new(proximo: uiStrings);

            Exibicao primeiro = uiPets;
            primeiro.Exibe(resultado);
        }
    }
}
