using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Aluno;

public class CreateAlunoDto
{
    [Required(ErrorMessage = "{0} é obrigatório!")]
    [StringLength(100)]
    [DisplayName("Nome do Aluno")]
    public string? Nome { get; set; }

    [Required]
    public int MatriculaId { get; set; }
}
