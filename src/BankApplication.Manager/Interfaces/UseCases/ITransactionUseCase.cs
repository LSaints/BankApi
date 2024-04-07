using BankApplication.Domain;

namespace BankApplication.Manager;

public interface ITransactionUseCase
{
    Task<IEnumerable<Transaction>> GetAll();
    Task<Transaction> GetById(Guid Id);
    Task<Transaction> Create(Transaction transaction);
    Task Update(Transaction transaction);
    Task Delete(Guid Id);
}
