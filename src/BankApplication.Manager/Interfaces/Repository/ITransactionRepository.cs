using BankApplication.Domain;

namespace BankApplication.Manager;

public interface ITransactionRepository
{
    Task<IEnumerable<Transaction>> GetAll();
    Task<Transaction> GetById(Guid Id);
    Task<Transaction> Create(Transaction transaction);
    Task Update(Transaction transaction);
    Task<Transaction> Delete(Guid Id);
}
