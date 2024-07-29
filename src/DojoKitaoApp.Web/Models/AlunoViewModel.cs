using System.ComponentModel.DataAnnotations;

namespace DojoKitaoApp.Web.Models;

public class AlunoViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome do Aluno é obrigatório")]
    [StringLength(100)]
    public string? Nome { get; set; }

    [Required]
    [StringLength(150)]
    public string? Sobrenome { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Data de Nascimento")]
    public DateTime? DataNascimento { get; set; }

    public EnderecoViewModel? Endereco { get; set; }
}
