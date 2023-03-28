using System.Reflection;

namespace Alura.Adopet.Console.UI
{
    internal static class MotorExibicao
    {
        public static void ExibeInformacao<T>(T resultado)
        {
            var cadeia = Assembly.GetExecutingAssembly()
                .DefinedTypes
                .Where(x => x.IsGenericType && typeof(IExibicao<T>).IsAssignableFrom(x));

            foreach(var tipo in cadeia)
            {
                Type typeExibicao = tipo.GetInterfaces().Select(i => i.GetGenericArguments().First()).First();
                if (resultado!.GetType().Equals(typeExibicao))
                {
                    var constructed = tipo.MakeGenericType(typeof(T));
                    if (constructed is not null)
                    {
                        IExibicao<T>? exibicao = (IExibicao<T>?)Activator.CreateInstance(constructed);
                        exibicao!.Exibe(resultado);
                        break;
                    }
                }
            }
        }
    }
}
