using System.ComponentModel.DataAnnotations;

namespace DojoKitaoApp.Libraries.Domain.Entities;

public class Aluno
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Nome { get; set; }

    [Required]
    public int MatriculaId { get; set; }
    public virtual Matricula? Matricula { get; set; }
}
