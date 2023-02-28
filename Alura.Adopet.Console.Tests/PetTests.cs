using Alura.Adopet.Console.Tests.Builder;
using Alura.Adopet.Console.Tests.Validador;
using Xunit.Abstractions;

namespace Alura.Adopet.Console.Tests
{
    public class PetTests:IDisposable
    {
        private readonly Pet _pet;
        private readonly PetValidador _validador;
        private readonly ITestOutputHelper? _output;
        public PetTests(ITestOutputHelper _saida)
        {
            _pet = PetBuilder.Build();
            _validador= ValidadorBuilder.Build();
            _output= _saida;
            _output.WriteLine("Invocando o construtor.");
        }
        [Fact]
        public void CriaUmObjetoPetValido()
        {
            //Arrange           
 
            //Act
            var result = _validador.Validate(_pet);

            //Assert
            Assert.True(result.IsValid);

        }

        [Fact]
        public void CriaUmObjetoPetComNomevazio()
        {
            //Arrange          
            _pet.Nome= string.Empty;      

            //Act
            var result = _validador.Validate(_pet);

            //Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors,x=>x.ErrorMessage== "Nome não pode ser vazio.");
            Assert.Contains(result.Errors, x => x.ErrorMessage == "Mínimo de 3 caracteres.");
        }

        [Fact]
        public void CriaUmObjetoPetComNomeNulo()
        {
            //Arrange         
            _pet.Nome = null;         

            //Act
            var result = _validador.Validate(_pet);

            //Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, x => x.ErrorMessage == "Nome não pode ser nulo.");
        }

        [Fact]
        public void CriaUmObjetoPetComIdVazio()
        {
            //Arrange     
            _pet.Id = Guid.Empty;         

            //Act
            var result = _validador.Validate(_pet);

            //Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, x => x.ErrorMessage == "O Id não pode ser vazio.");
        }

        [Fact]
        public void CriaUmObjetoPetComTipoPetInvalido()
        {
            //Arrange         
            _pet.Tipo = (TipoPet)(-1);   

            //Act
            var result = _validador.Validate(_pet);

            //Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, x => x.ErrorMessage == "Tipo de Pet não definido.");
        }

        public void Dispose()
        {
            _output.WriteLine("Limpando recursos.");
        }
    }
}