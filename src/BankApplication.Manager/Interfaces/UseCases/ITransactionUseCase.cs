using BankApplication.Domain;

namespace BankApplication.Manager;

public interface ITransactionUseCase
{
    Task<IEnumerable<TransactionOutputModel>> GetAll();
    Task<TransactionOutputModel> GetById(Guid Id);
    Task<TransactionOutputModel> Create(TransactionInputModel transaction);
    Task Update(Transaction transaction);
    Task Delete(Guid Id);
}
