using System.ComponentModel.DataAnnotations;
using DojoKitaoApp.Libraries.Domain.Entities.Enums;

namespace DojoKitaoApp.Libraries.Domain.Entities;

public class Treino
{
    public int Id { get; set; }

    public string? Descricao { get; set; }

    [Required]
    public ArteMarcial ArteMarcial { get; set; }

    public virtual ICollection<Aula>? Aulas { get; set; }
}
