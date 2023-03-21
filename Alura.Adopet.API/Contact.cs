using Microsoft.OpenApi.Models;

internal class Contact : OpenApiContact
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Url { get; set; }
}