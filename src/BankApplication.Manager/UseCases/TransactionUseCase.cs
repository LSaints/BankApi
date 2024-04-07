using BankApplication.Domain;

namespace BankApplication.Manager;

public class TransactionUseCase : ITransactionUseCase
{
    private readonly ITransactionRepository _repository;

    public TransactionUseCase(ITransactionRepository repository)
    {
        _repository = repository;
    }
    public async Task<Transaction> Create(Transaction transaction)
    {
        return await _repository.Create(transaction);
    }

    public async Task Delete(Guid Id)
    {
        await _repository.Delete(Id);
    }

    public async Task<IEnumerable<Transaction>> GetAll()
    {
        return await _repository.GetAll();
    }

    public Task<Transaction> GetById(Guid Id)
    {
        return _repository.GetById(Id);
    }

    public Task Update(Transaction transaction)
    {
        return _repository.Update(transaction);
    }
}
