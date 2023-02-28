using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Tests
{
    public class ConsoleTests
    {
        [Fact]
        public void TestaComandoHelpUmArgumento() 
        {
            //Arrange
            string[] args = { "help" };
           
           //Act
            Program.Main(args);
            Program.Executacomando();
          
            //Assert
            Assert.NotNull(args);

        }
    }
}
