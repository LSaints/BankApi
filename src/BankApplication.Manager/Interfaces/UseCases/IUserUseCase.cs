using BankApplication.Domain;

namespace BankApplication.Manager;

public interface IUserUseCase
{
    Task<IEnumerable<UserOutputModel>> GetAll();
    Task<UserOutputModel> GetById(Guid Id);
    Task<UserOutputModel> Create(UserInputModel user);
    Task<UserOutputModel> Update(UserUpdateModel user);
    Task<UserOutputModel> Delete(Guid Id);
}
