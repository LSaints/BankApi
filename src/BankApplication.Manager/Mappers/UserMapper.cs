using AutoMapper;
using BankApplication.Domain;

namespace BankApplication.Manager;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<User, UserOutputModel>();
        CreateMap<UserInputModel, UserOutputModel>();
        CreateMap<UserInputModel, User>();
        CreateMap<UserUpdateModel, User>();
    }
}
