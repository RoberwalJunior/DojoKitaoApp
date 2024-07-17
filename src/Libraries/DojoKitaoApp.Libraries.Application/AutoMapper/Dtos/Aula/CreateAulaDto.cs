using System.ComponentModel.DataAnnotations;

namespace DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Aula;

public class CreateAulaDto
{
    [Required]
    public int TreinoId { get; set; }

    [Required]
    public int AlunoId { get; set; }

    [Required]
    public string? Data { get; set; }
}
