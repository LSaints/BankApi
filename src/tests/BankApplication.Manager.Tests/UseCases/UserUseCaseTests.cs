using AutoMapper;
using Moq;

namespace BankApplication.Manager.Tests;

public class UserUseCaseTests
{
    private UserUseCase _useCase;
    private readonly Mock<IUserRepository> _repositoryMock;

    public UserUseCaseTests()
    {
        _repositoryMock = new Mock<IUserRepository>();
        _useCase = new UserUseCase(_repositoryMock.Object, new Mock<IMapper>().Object);
    }
}
