using Alura.Adopet.Console.Tests.Validador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Tests.Builder
{
    internal static class ValidadorBuilder
    {
        internal static PetValidador Build()
        {           
            return new PetValidador();
        }
    }
}
