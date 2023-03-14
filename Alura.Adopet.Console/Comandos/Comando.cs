namespace Alura.Adopet.Console.Comandos
{
    internal abstract class Comando : IComando
    {
        public async Task<IResultado> ExecutarAsync(string[] args)
        {
			try
			{
				return await ExecAsync(args);
			}
			catch (Exception ex)
			{
				return new Erro(ex.Message);
			}
        }

		public abstract Task<IResultado> ExecAsync(string[] args);
    }
}
