using AutoMapper;
using BankApplication.Domain;

namespace BankApplication.Manager;

public class UserUseCase : IUserUseCase
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public UserUseCase(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UserOutputModel> Create(UserInputModel user)
    {
        var userModel = _mapper.Map<User>(user);
        await _repository.Create(userModel);
        return _mapper.Map<UserOutputModel>(userModel);
    }

    public async Task<UserOutputModel> Delete(Guid Id)
    {
        return _mapper.Map<UserOutputModel>(await _repository.Delete(Id));
    }

    public async Task<IEnumerable<UserOutputModel>> GetAll()
    {
       return _mapper.Map<IEnumerable<User>, IEnumerable<UserOutputModel>>(await _repository.GetAll());
    }

    public async Task<UserOutputModel> GetById(Guid Id)
    {
        return _mapper.Map<UserOutputModel>(await _repository.GetById(Id));
    }

    public async Task<UserOutputModel> Update(UserUpdateModel user)
    {
        var userModel = _mapper.Map<User>(user);
        return _mapper.Map<User, UserOutputModel>(await _repository.Update(userModel));
    }
}
