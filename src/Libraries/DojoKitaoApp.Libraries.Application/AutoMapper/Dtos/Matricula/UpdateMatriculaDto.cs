using System.ComponentModel.DataAnnotations;

namespace DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Matricula;

public class UpdateMatriculaDto
{
    [StringLength(150, ErrorMessage = "Não pode ter mais do que 150 caracteres.")]
    public string? Endereco { get; set; }
}
