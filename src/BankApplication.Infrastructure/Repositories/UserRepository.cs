using BankApplication.Domain;
using BankApplication.Manager;
using Microsoft.EntityFrameworkCore;

namespace BankApplication.Infrastructure;

public class UserRepository : IUserRepository
{
    private readonly BankApplicationContext _context;

    public UserRepository(BankApplicationContext context)
    {
        _context = context;
    }

    public async Task<User> Create(User user)
    {
        user.Id = new Guid();
        await _context.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> Delete(Guid Id)
    {
        var user = await _context.users.FindAsync(Id);
        if (user == null)
            throw new Exception("Usuario não encontrado");
        var userToRemove = _context.users.Remove(user);
        await _context.SaveChangesAsync();
        return userToRemove.Entity;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _context.users.AsNoTracking().ToListAsync();
    }

    public async Task<User> GetById(Guid Id)
    {
        return await _context.users.SingleAsync(e => e.Id == Id);
    }

    public async Task<User> Update(User user)
    {
        var userFind = await _context.users.FindAsync(user.Id);
        if (userFind == null)
            throw new Exception("Usuario não encontrado");
        _context.Entry(userFind).CurrentValues.SetValues(user);
        await _context.SaveChangesAsync();
        return userFind;
    }
}
