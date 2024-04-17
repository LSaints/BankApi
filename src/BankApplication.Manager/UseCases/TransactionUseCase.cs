using AutoMapper;
using BankApplication.Domain;

namespace BankApplication.Manager;

public class TransactionUseCase : ITransactionUseCase
{
    private readonly ITransactionRepository _repository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public TransactionUseCase(ITransactionRepository repository, IUserRepository userRepository, IMapper mapper)
    {
        _repository = repository;
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<TransactionOutputModel> Create(TransactionInputModel transaction)
    {
        var user = await _userRepository.GetById(transaction.SenderId);
        if (user.Amount < transaction.Amount)
            throw new Exception("Usuario não tem saldo suficiente");

        var transactionModel = _mapper.Map<Transaction>(transaction);
        transactionModel.Date = DateTime.Now;
        await _repository.Create(transactionModel);
        return _mapper.Map<TransactionOutputModel>(transactionModel);
    }

    public async Task Delete(Guid Id)
    {
        await _repository.Delete(Id);
    }

    public async Task<IEnumerable<TransactionOutputModel>> GetAll()
    {

        return _mapper.Map<IEnumerable<Transaction>, IEnumerable<TransactionOutputModel>>(await _repository.GetAll());
    }

    public async Task<TransactionOutputModel> GetById(Guid Id)
    {
        
        return _mapper.Map<Transaction, TransactionOutputModel>(await _repository.GetById(Id));
    }

    public Task Update(Transaction transaction)
    {
        return _repository.Update(transaction);
    }
}
