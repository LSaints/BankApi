namespace BankApplication.Domain;

public class User
{
    public Guid Id {get; set;}
    public string Name {get; set;}
    public string Email {get; set;}
    public string Password {get; set;}
    public ICollection<Transaction>? SentTransactions { get; set; }
    public ICollection<Transaction>? ReceivedTransactions { get; set; }
}
