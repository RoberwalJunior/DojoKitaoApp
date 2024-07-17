using System.ComponentModel.DataAnnotations;
using DojoKitaoApp.Libraries.Domain.Entities.Enums;

namespace DojoKitaoApp.Libraries.Domain.Entities;

public class Matricula
{
    public int Id { get; set; }

    [Required]
    public int AlunoId { get; set; }
    public virtual Aluno? Aluno { get; set; }

    [Required]
    public ArteMarcial ArteMarcial { get; set; }
}
