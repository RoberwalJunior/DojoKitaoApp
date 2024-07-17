using System.ComponentModel.DataAnnotations;

namespace DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Aluno;

public class UpdateAlunoDto
{
    [Required(ErrorMessage = "{0} é obrigatório!")]
    [StringLength(100, ErrorMessage = "Não pode ter mais que 100 caracteres.")]
    [Display(Name = "Nome do Aluno")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório!")]
    [StringLength(150, ErrorMessage = "Não pode ter mais que 150 caracteres.")]
    [Display(Name = "Sobrenome do Aluno")]
    public string? Sobrenome { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório!")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
    [Display(Name = "Data de Nascimento")]
    public DateTime? DataNascimento { get; set; }
}
