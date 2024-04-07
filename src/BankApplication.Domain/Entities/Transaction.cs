namespace BankApplication.Domain;

public class Transaction
{
    public Guid Id {get; set;}
    public Guid SenderId {get; set;}
    public User Sender {get; set;}
    public User Receiver {get; set;}
    public Guid ReceiverId {get; set;}
    public double Amount {get; set;}
    public string? Description {get; set;}
    public DateTime Date {get; set;}
}
