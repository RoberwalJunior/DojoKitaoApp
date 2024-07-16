using System.ComponentModel.DataAnnotations;

namespace DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Aluno;

public class CreateAlunoDto
{
    [Required]
    [StringLength(100)]
    public string? Nome { get; set; }

    [Required]
    public int MatriculaId { get; set; }
}
