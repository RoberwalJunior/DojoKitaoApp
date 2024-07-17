using System.ComponentModel.DataAnnotations;

namespace DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Matricula;

public class UpdateMatriculaDto
{
    [Required(ErrorMessage = "{0} é obrigatório!")]
    [Display(Name = "Id do Aluno")]
    public int AlunoId { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório!")]
    [Display(Name = "Arte Marcial")]
    [Range(0, 1)]
    public int ArteMarcial { get; set; }
}
