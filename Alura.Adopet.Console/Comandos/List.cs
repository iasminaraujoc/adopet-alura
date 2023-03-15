using Alura.Adopet.Console.Services;

namespace Alura.Adopet.Console.Comandos
{
    [Util.DocComando($" adopet list  comando que exibe no terminal o conteúdo importado no servidor.")]
    internal class List : Comando
    {
        PetService clientPet;

        public List()
        {
            clientPet = new PetService();
        }

        public override async Task<IResultado> ExecAsync(string[] args)
        {
            return await this.ListPets();
        }

        public async Task<IResultado> ListPets()
        {
            var pets = await clientPet.ListAsync();
            return new Ok(pets);
        }

    }
}
