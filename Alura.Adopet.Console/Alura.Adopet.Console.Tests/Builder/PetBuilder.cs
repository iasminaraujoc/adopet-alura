using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Tests.Builder;
internal static class PetBuilder
{
   internal static Pet Build()
    {
        Random rd = new Random();
        var tipo = rd.Next(0, 1);
        var tipoEnum = tipo == 0 ? TipoPet.Gato : TipoPet.Cachorro;
        return new Pet(Guid.NewGuid(),
                       $"Animal{Guid.NewGuid().ToString().Substring(0,8)}",
                       tipoEnum);
    }
}
