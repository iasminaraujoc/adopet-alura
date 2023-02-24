using System.Net.Http.Headers;
using System.Net.Http.Json;
using Alura.Adopet.Console;

const string IMPORT = "import";
const string HELP = "help";
const string SHOW = "show";

async Task Import(string caminhoArquivo)
{
    List<Pet> listaDePet = new List<Pet>();

    using (StreamReader sr = new StreamReader(caminhoArquivo))
    {
        while (!sr.EndOfStream)
        {
            string[] propriedades = sr.ReadLine().Split(';');
            Pet pet = new Pet(Guid.Parse(propriedades[0]),
              propriedades[1],
              TipoPet.Cachorro
             );

            Console.WriteLine(pet);
            listaDePet.Add(pet);
        }
    }
    foreach (var pet in listaDePet)
    {
        try
        {
            var resposta = await CreatePetAsync(pet);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    Console.WriteLine("Importação concluída!");
    Console.ReadKey();
}

void Help()
{
    Console.WriteLine("Lista de comandos.");
    
    Console.WriteLine($"adopet {HELP} <parametro> ous simplemente adopet {HELP}  " +
            "comando que exibe informações de ajuda dos comandos.");
    Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
    Console.WriteLine("Realiza a importação em lote de um arquivos de pets.");
    Console.WriteLine("Comando possíveis: ");
    Console.WriteLine($" adopet {IMPORT} <arquivo> comando que realiza a importação do arquivo de pets.");
    Console.WriteLine($" adopet {SHOW}   <arquivo> comando que exibe no terminal o conteúdo do arquivo importado." + "\n\n\n\n");
    Console.WriteLine($"Execute 'adopet.exe {HELP} [comando]' para obter mais informações sobre um comando." + "\n\n\n");
    
    Console.ReadKey();
}

void HelpDoComando(string docComando)
{
    if (docComando.Equals(IMPORT))
    {
        Console.WriteLine($" adopet {IMPORT} <arquivo> " +
            "comando que realiza a importação do arquivo de pets.");
    }
    if (docComando.Equals(SHOW))
    {
        Console.WriteLine($" adopet {SHOW} <arquivo>  comando que " +
            "exibe no terminal o conteúdo do arquivo importado.");
    }
}

void Show(string caminhoArquivo)
{
    using (StreamReader sr = new StreamReader(caminhoArquivo))
    {
        Console.WriteLine("----- Importaddos os dados abaixo -----");
        while (!sr.EndOfStream)
        {
            string[] propriedades = sr.ReadLine().Split(';');
            Pet pet = new Pet(Guid.Parse(propriedades[0]),
            propriedades[1],
            TipoPet.Cachorro
            );
            Console.WriteLine(pet);
        }
    }
    Console.ReadKey();
}


HttpClient client = ConfiguraHttpClient("https://localhost:7136");
Console.ForegroundColor = ConsoleColor.Green;
try
{
    string comando = args[0];

    switch (comando.Trim())
    {
        case IMPORT:
            await Import(caminhoArquivo:args[1]);
            break;
        case HELP:
            if (args.Length == 2) 
            {
                HelpDoComando(docComando: args[1]);
            }
            else
            {
                Help();
            }
            break;
        case SHOW:
            Show(caminhoArquivo:args[1]);
            break;
        default:
            Console.WriteLine("Comando inválido!");
            break;
    }
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

HttpClient ConfiguraHttpClient(string url)
{
    HttpClient _client = new HttpClient();
    _client.DefaultRequestHeaders.Accept.Clear();
    _client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));
    _client.BaseAddress = new Uri(url);
    return _client;
}

Task<HttpResponseMessage> CreatePetAsync(Pet pet)
{
    HttpResponseMessage? response = null;
    using (response = new HttpResponseMessage())
    {                    
        return client.PostAsJsonAsync("pet/add",pet);
    }
}