using System.ComponentModel.DataAnnotations;
using DojoKitaoApp.Libraries.Domain.Entities.Enums;

namespace DojoKitaoApp.Libraries.Domain.Entities;

public class Matricula
{
    public int Id { get; set; }

    public virtual Aluno? Aluno { get; set; }

    [Required]
    public ArteMarcial ArteMarcial { get; set; }

    [MaxLength(150)]
    public string? Endereco { get; set; }
}
