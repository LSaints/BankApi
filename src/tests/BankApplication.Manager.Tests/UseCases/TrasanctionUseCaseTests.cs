using AutoMapper;
using Moq;

namespace BankApplication.Manager.Tests;

public class TrasanctionUseCaseTests
{
    private TransactionUseCase _useCase;
    private readonly Mock<ITransactionRepository> _repositoryMock;

    public TrasanctionUseCaseTests()
    {
        _repositoryMock = new Mock<ITransactionRepository>();
        _useCase = new TransactionUseCase(_repositoryMock.Object, new Mock<IMapper>().Object);
    }
}
