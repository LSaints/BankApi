using BankApplication.Domain;

namespace BankApplication.Manager;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAll();
    Task<User> GetById(Guid Id);
    Task<User> Create(User user);
    Task<User> Deposit(Guid Id, double Amount);
    Task<User> Update(User user);
    Task<User> Delete(Guid Id);
}
