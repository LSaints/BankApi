using BankApplication.Domain;

namespace BankApplication.Manager;

public class UserUseCase : IUserUseCase
{
    private readonly IUserRepository _repository;

    public UserUseCase(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<User> Create(User user)
    {
        return await _repository.Create(user);
    }

    public async Task<User> Delete(Guid Id)
    {
        return await _repository.Delete(Id);
    }

    public async Task<IEnumerable<User>> GetAll()
    {
       return await _repository.GetAll();
    }

    public async Task<User> GetById(Guid Id)
    {
        return await _repository.GetById(Id);
    }

    public async Task<User> Update(User user)
    {
        return await _repository.Update(user);
    }
}
