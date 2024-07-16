using System.ComponentModel.DataAnnotations;

namespace DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Matricula;

public class CreateMatriculaDto
{
    [StringLength(150)]
    public string? Endereco { get; set; }

    [Required]
    public int ArteMarcial { get; set; }
}
