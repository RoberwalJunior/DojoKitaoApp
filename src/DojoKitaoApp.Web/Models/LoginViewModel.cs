using System.ComponentModel.DataAnnotations;

namespace DojoKitaoApp.Web.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "{0} é obrigatório!")]
    [Display(Name = "E-mail")]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório!")]
    [DataType(DataType.Password)]
    public string? Senha { get; set; }
}
