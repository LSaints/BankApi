using AutoMapper;
using BankApplication.Domain;

namespace BankApplication.Manager;

public class TransactionMapper : Profile
{
    public TransactionMapper()
    {
        CreateMap<TransactionInputModel, Transaction>();
        CreateMap<Transaction, TransactionOutputModel>();
    }
}
