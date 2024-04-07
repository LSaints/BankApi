using BankApplication.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BankApplication.API;

public static class DbContextConfiguration
{
    
    public static void UseDbContextConfiguration(this IServiceCollection services, WebApplicationBuilder builder) 
    {
        var connectionString = builder.Configuration.GetConnectionString("Database");
        services.AddDbContext<BankApplicationContext>(
            options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);
    }
}
