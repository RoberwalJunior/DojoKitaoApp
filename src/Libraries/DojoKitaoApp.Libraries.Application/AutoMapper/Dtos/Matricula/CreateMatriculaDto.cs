using System.ComponentModel.DataAnnotations;

namespace DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Matricula;

public class CreateMatriculaDto
{
    [StringLength(150, ErrorMessage = "Não pode ter mais do que 150 caracteres.")]
    public string? Endereco { get; set; }

    [Required(ErrorMessage = "Arte Marcial é obrigatório!")]
    [Range(0, 1)]
    public int ArteMarcial { get; set; }
}
