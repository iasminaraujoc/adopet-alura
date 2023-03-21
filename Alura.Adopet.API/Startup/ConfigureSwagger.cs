namespace Alura.Adopet.API.Startup
{
    public static class ConfigureSwagger
    {
        public static void ConfigureSwaggerApp(this IApplicationBuilder app)
        {
            // Ativando a interface Swagger
            app.UseSwaggerUI(
                c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoAPI V1");
                    c.RoutePrefix = string.Empty;
                }
            );
        }
    }
}
