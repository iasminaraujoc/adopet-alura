namespace Alura.Adopet.Console.Comandos
{
    internal abstract class Comando : IComando
    {
        public Task<IResultado> ExecutarAsync(string[] args)
        {
			try
			{
				return ExecAsync(args);
			}
			catch (Exception ex)
			{
				return Task.FromResult<IResultado>(new Erro(ex.Message));
			}
        }

		public abstract Task<IResultado> ExecAsync(string[] args);
    }
}
