namespace BankApplication.API;

public static class CorsConfiguration
{
    public static void UseCorsConfiguration(this IServiceCollection services)
    {
        services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });
    }

    public static void UseAppCorsConfiguration(this IApplicationBuilder builder)
    {
        builder.UseCors("AllowAllOrigins");
    }
}
