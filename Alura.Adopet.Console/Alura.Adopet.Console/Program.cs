using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class Program
{
    static HttpClient client;
    public static void Main(string[] args)
    {
        client = ConfiguraHttpClient("https://localhost:7136");
        EscolheComando(args, client);
        Console.ReadKey();
    }

    static HttpClient ConfiguraHttpClient(string url)
    {
        HttpClient _client = new HttpClient();
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        _client.BaseAddress = new Uri(url);
        return _client;
    }

    static Task<HttpResponseMessage> CreatePetAsync(Pet pet)
    {
        HttpResponseMessage? response = null;
        using (response = new HttpResponseMessage())
        {
            return client.PostAsJsonAsync("pet/add", pet);
        }
    }

    public static async Task<string> Import(string[] args, HttpClient client)
    {
        List<Pet> listaDePet = new List<Pet>();

        using (StreamReader sr = new StreamReader(args[1]))
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
        return "Importação concluída!";
    }

    public static string Help(string[] args)
    {

        if (args.Length == 1)
        {
            return $"adopet help <parametro> ou simplemente adopet help  " +
                    "comando que exibe informações de ajuda dos comandos." +
                    "Adopet (1.0) - Aplicativo de linha de comando (CLI)." +
                    "Realiza a importação em lote de um arquivos de pets." +
                    "Comando possíveis: " +
                    " adopet import <arquivo> comando que realiza a importação do arquivo de pets." +
                    " adopet show   <arquivo> comando que exibe no terminal o conteúdo do arquivo importado." + "\n\n\n\n" +
                    "Execute 'adopet.exe help [comando]' para obter mais informações sobre um comando." + "\n\n\n";
        }
        else if (args.Length == 2)
        {
            if (args[1].Equals("import"))
            {
                return " adopet import <arquivo> " +
                    "comando que realiza a importação do arquivo de pets.";
            }
            if (args[1].Equals("show"))
            {
                return " adopet show <arquivo>  comando que " +
                    "exibe no terminal o conteúdo do arquivo importado.";
            }
        }

        return string.Empty;
    }

    public static string Show(string[] args)
    {
        string retorno = string.Empty;
        using (StreamReader sr = new StreamReader(args[1]))
        {
            retorno = "----- Importados os dados abaixo -----";
            while (!sr.EndOfStream)
            {
                string[] propriedades = sr.ReadLine().Split(';');
                Pet pet = new Pet(Guid.Parse(propriedades[0]),
                propriedades[1],
                TipoPet.Cachorro
                );
                retorno += "\n" + pet;
            }
        }

        return retorno;
    }

    public static async Task<string> EscolheComando(string[] args, HttpClient client)
    {
        string retorno = string.Empty;
        Console.ForegroundColor = ConsoleColor.Green;
        try
        {
            switch (args[0].Trim())
            {
                case "import":
                    Console.WriteLine("Comando Import.");
                    Console.WriteLine(await Import(args, client));
                    retorno = "import";
                    break;
                case "help":
                    Console.WriteLine("Lista de comandos.");
                    Console.WriteLine(Help(args));
                    retorno = "help";
                    break;
                case "show":
                    Console.WriteLine("Comando Show.");
                    Console.WriteLine(Show(args));
                    retorno = "show";
                    break;
                default:
                    Console.WriteLine("Comando inválido!");
                    retorno = "invalido";
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

        return retorno;
    }

}


public class Pet
{
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public TipoPet Tipo { get; set; }
    public Pet(Guid id, string? nome, TipoPet tipo)
    {
        Id = id;
        Nome = nome;
        Tipo = tipo;
    }
    public override string ToString()
    {
        return $"{this.Id} - {this.Nome} - {this.Tipo}";
    }
}

public enum TipoPet
{
    Gato,
    Cachorro
}
