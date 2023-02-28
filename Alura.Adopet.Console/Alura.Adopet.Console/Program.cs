using Alura.Adopet.Console.Comandos;

Dictionary<string, IComando> dicionarioDeComandos;
Dictionary<string, IComando> CreateDicionario()
{
    dicionarioDeComandos = new Dictionary<string, IComando>();
    dicionarioDeComandos.Add("import", new Import());
    dicionarioDeComandos.Add("help", new Help());
    dicionarioDeComandos.Add("show", new Show());
    return dicionarioDeComandos;
}

Console.ForegroundColor = ConsoleColor.Green;
try
{
    dicionarioDeComandos = CreateDicionario();

    string comando = args[0];// pego o argumento
    string argumento=string.Empty;
    if (args.Length>1)
    {
        argumento = args[1];
    } 
    var comandoObjeto = dicionarioDeComandos[comando];//crio o objeto de comando

    comandoObjeto.Argumento = argumento;//configura o comando
  
    await comandoObjeto.ExecutarAsync();

    
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Aconteceu um exceção: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.White;
}
