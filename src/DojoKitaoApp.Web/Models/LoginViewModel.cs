using System.ComponentModel.DataAnnotations;

namespace DojoKitaoApp.Web.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "{0} é obrigatório!")]
    [Display(Name = "E-mail")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório!")]
    public string? Senha { get; set; }
}
