using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Tests
{
    public class MainTests
    {

        #region ExecutaComando

        [Fact]
        public void ValidaExecutaComandoComHelpComUmArgumento()
        {
            //Arrange
            var argumentos = new string[] { "help" };

            //Act
            var result = Program.EscolheComando(argumentos, null);

            //Assert
            Assert.Contains(result.Result,"adopet help <parametro>");
        }
        [Fact]
        public void ValidaExecutaComandoComShow()
        {
            //Arrange
            var argumentos = new string[] { "show" };

            //Act
            var result = Program.EscolheComando(argumentos, null);

            //Assert
            Assert.Contains(result.Result,"show");
        }

        [Fact]
        public void ValidaExecutaComandoImport()
        {
            //Arrange
            var argumentos = new string[] { "import" };

            //Act
            var result = Program.EscolheComando(argumentos, null);

            //Assert
            Assert.Contains(result.Result, "import");
        }

        [Fact]
        public void ValidaExecutaComandoInvalido()
        {
            //Arrange
            var argumentos = new string[] {"xxxxxxx" };

            //Act
            var result = Program.EscolheComando(argumentos, null);

            //Assert
            Assert.Contains(result.Result, "invalido");
        }

        #endregion

        #region Help
        [Fact]
        public void ValidaMetodoHelpComUmArgumento()
        {
            //Arrange
            var argumentos = new string[] { "help" };

            //Act
            var result = Program.Help(argumentos);

            //Assert
            Assert.Contains("adopet help <parametro>", result);
        }

        [Fact]
        public void ValidaMetodoHelpComDoisArgumentoShow()
        {
            //Arrange
            var argumentos = new string[] { "help","show" };

            //Act
            var result = Program.Help(argumentos);

            //Assert
            Assert.Contains(" adopet show <arquivo>", result);
        }

        [Fact]
        public void ValidaMetodoHelpComDoisArgumentoImport()
        {
            //Arrange
            var argumentos = new string[] { "help", "import" };

            //Act
            var result = Program.Help(argumentos);

            //Assert
            Assert.Contains(" adopet import <arquivo>", result);
        }
        #endregion


    }
}
