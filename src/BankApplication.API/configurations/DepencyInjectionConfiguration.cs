using BankApplication.Infrastructure;
using BankApplication.Manager;
using Microsoft.EntityFrameworkCore;

namespace BankApplication.API;

public static class DepencyInjectionConfiguration
{
      public static void UseDepencyInjectionConfiguration(this IServiceCollection services) 
    {
        services.AddScoped<DbContext, BankApplicationContext>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserUseCase, UserUseCase>();

        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<ITransactionUseCase, TransactionUseCase>();
    }
}
