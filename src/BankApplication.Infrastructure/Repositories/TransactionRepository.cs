using BankApplication.Domain;
using BankApplication.Manager;
using Microsoft.EntityFrameworkCore;

namespace BankApplication.Infrastructure;

public class TransactionRepository : ITransactionRepository
{
    private readonly BankApplicationContext _context;

    public TransactionRepository(BankApplicationContext context)
    {
        _context = context;
    }
    public async Task<Transaction> Create(Transaction transaction)
    {
        await _context.transactions.AddAsync(transaction);
        await _context.SaveChangesAsync();
        return transaction;
    }

    public async Task<Transaction> Delete(Guid Id)
    {
        var transaction = await _context.transactions.FindAsync(Id);
        if (transaction == null)
            throw new Exception("Transação não encontrada");
        var transactionToRemove = _context.transactions.Remove(transaction);
        await _context.SaveChangesAsync();
        return transactionToRemove.Entity;
    }

    public async Task<IEnumerable<Transaction>> GetAll()
    {
        return await _context.transactions
        .Include(e => e.Sender)
        .Include(e => e.Receiver)
        .AsNoTracking()
        .OrderByDescending(e => e.Date)
        .ToListAsync();
    }

    public async Task<Transaction> GetById(Guid Id)
    {
        return await _context.transactions
        .Include(e => e.Sender)
        .Include(e => e.Receiver)
        .SingleAsync(e => e.Id == Id);
    }

    public async Task Update(Transaction transaction)
    {
        var transactionFind = await _context.transactions.FindAsync(transaction.Id);
        if (transactionFind == null)
            throw new Exception("Transação não encontrada");
        await _context.SaveChangesAsync();
    }
}
