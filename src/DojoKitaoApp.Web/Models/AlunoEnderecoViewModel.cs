using System.ComponentModel.DataAnnotations;

namespace DojoKitaoApp.Web.Models;

public class AlunoEnderecoViewModel
{
    [Required(ErrorMessage = "Nome do Aluno é obrigatório")]
    [StringLength(100, ErrorMessage = "Não pode ter mais do que 100 caracteres.")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "Sobrenome do Aluno é obrigatório")]
    [StringLength(150, ErrorMessage = "Não pode ter mais do que 150 caracteres.")]
    public string? Sobrenome { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]
    [DataType(DataType.Date)]
    [Display(Name = "Data de Nascimento")]
    public DateTime? DataNascimento { get; set; }

    [StringLength(50, ErrorMessage = "Não pode ter mais do que 50 caracteres.")]
    public string? Logradouro { get; set; }

    public int? Numero { get; set; }

    [StringLength(50, ErrorMessage = "Não pode ter mais do que 50 caracteres.")]
    public string? Complemento { get; set; }

    [StringLength(50, ErrorMessage = "Não pode ter mais do que 10 caracteres.")]
    public string? CEP { get; set; }
}
