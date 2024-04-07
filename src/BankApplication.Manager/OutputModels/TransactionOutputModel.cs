using BankApplication.Domain;

namespace BankApplication.Manager;

public class TransactionOutputModel
{
    public Guid Id {get; set;}
    public DateTime Date {get; set;}
    public double Amount { get; set; }
    public string? Description { get; set; }
    public UserOutputModel Sender { get; set; }
    public UserOutputModel Receiver { get; set; }
}
 