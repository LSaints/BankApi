using System.ComponentModel.DataAnnotations;

namespace BankApplication.Manager;

public class UserUpdateModel
{
    [Required]
    public Guid Id {get; set;}

    [Required]    
    [StringLength(40, MinimumLength = 3, 
    ErrorMessage = "Nome do usuario não pode exceder o limite de 40 caracteres, e deve ter no minimo 3 caracteres")]
    public string Name {get; set;}

    [Required]
    [EmailAddress]
    public string Email {get; set;}

    [Required]
    public string Password {get; set;}
}
