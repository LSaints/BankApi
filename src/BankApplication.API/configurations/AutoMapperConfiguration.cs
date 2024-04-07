using BankApplication.Manager;

namespace BankApplication.API;

public static class AutoMapperConfiguration
{
    public static void UseAutoMapperConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(
            typeof(TransactionInputModel),
            typeof(TransactionOutputModel));
            
        services.AddAutoMapper(
            typeof(UserOutputModel),
            typeof(UserInputModel),
            typeof(UserUpdateModel));
    }
}
