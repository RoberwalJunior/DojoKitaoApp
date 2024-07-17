using System.ComponentModel.DataAnnotations;
using DojoKitaoApp.Libraries.Domain.Entities.Enums;

namespace DojoKitaoApp.Libraries.Domain.Entities;

public class Treino
{
    public int Id { get; set; }

    public string? Descricao { get; set; }

    [Required]
    public ArteMarcial ArteMarcial { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
    public DateTime Data { get; set; }

    public virtual ICollection<Aula>? Aulas { get; set; }
}
