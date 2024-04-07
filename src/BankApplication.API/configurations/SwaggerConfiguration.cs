using Microsoft.OpenApi.Models;

namespace BankApplication.API;

public static class SwaggerConfiguration
{
    public static void UseSwaggerConfiguration(this IServiceCollection services) 
    {
        services.AddSwaggerGen(options => 
        {
            options.EnableAnnotations();
            options.SwaggerDoc("v1", new OpenApiInfo 
            {
                Version = "v1",
                Title = "Bank API",
                Description = "API simples para estudos de transações financeiras entre usuários",
                Contact = new OpenApiContact
                {
                    Name = "Repositório",
                    Url = new Uri("https://github.com/LSaints/BankApplication")
                }
            });
        });
    }
}
