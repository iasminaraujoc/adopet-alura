using System.Net.Http.Headers;
using System.Net.Http.Json;

HttpClient client = new HttpClient();
Console.ForegroundColor = ConsoleColor.Green;
List<string>? lista = null;
try
{
    switch (args[0].Trim())
    {
        case "import":
            // if (File.Exists(args[1]))
            // {
            //     lista = new List<string>();
            //     using (StreamReader sr = new StreamReader(args[1]))
            //     {
            //         //Console.WriteLine(sr.ReadToEnd());
            //         while (!sr.EndOfStream)
            //         {
            //             lista.Add(sr.ReadLine());
            //         }
            //     }
               List<Pet> listaDePet = new List<Pet>();
                
                using (StreamReader sr = new StreamReader(args[1]))
                {                  
                    while (!sr.EndOfStream)
                    {
                        Pet pet = new Pet();                        
                        string[] propriedades = sr.ReadLine().Split(';');
                        pet.Id=Guid.Parse(propriedades[0]);
                        pet.Nome=propriedades[1];
                        pet.Tipo=TipoPet.Cachorro;
                        listaDePet.Add(pet);

                    }
                }
                 foreach (var pet in listaDePet)
                 {
                    CreatePetAsync(pet);
                 }
                
                Console.WriteLine("Importação concluída!");
                Console.ReadKey();
            //}
            break;
        case "help":
            Console.WriteLine("Lista de comandos.");
            Console.ReadKey();
            break;
        case "show":
            if (lista != null)
            {
                Console.WriteLine("Lista de importação....");
                foreach (var item in lista)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Faltou importação do arquivo.");
            }
            Console.ReadKey();
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

 async Task<Uri> CreatePetAsync(Pet pet)
    {
        HttpResponseMessage? response = new HttpResponseMessage();

        client.BaseAddress = new Uri("https://localhost:7136");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        response = await client.PostAsJsonAsync(
            "pet/add", pet);
        response.EnsureSuccessStatusCode();

        return response.Headers.Location;
    }

internal class Pet
{
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public TipoPet Tipo { get; set; }
}

 enum TipoPet
    {
        Gato,
        Cachorro
    }