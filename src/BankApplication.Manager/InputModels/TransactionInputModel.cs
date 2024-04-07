using System.ComponentModel.DataAnnotations;

namespace BankApplication.Manager;

public class TransactionInputModel
{
    [Required(ErrorMessage = "Id do rementente deve ser informado")]
    public Guid SenderId { get; set; }

    [Required(ErrorMessage = "Id do destinatario deve ser informado")]
    public Guid ReceiverId { get; set; }

    [Required(ErrorMessage = "Valor da transação deve ser informado")]
    public double Amount { get; set; }
    
    [StringLength(100, ErrorMessage = "Descrição deve ter no máximo 100 caracteres")]
    public string? Description { get; set; }
}
