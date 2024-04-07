namespace BankApplication.API;

public static class ControllerConfiguration
{
    public static void UseControllerConfiguration(this IServiceCollection services)
    {
        services.AddControllers();
    }
}
