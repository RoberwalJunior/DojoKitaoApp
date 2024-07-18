using System.ComponentModel.DataAnnotations;

namespace DojoKitaoApp.Libraries.Domain.Entities;

public class Aula
{
    [Required]
    public int TreinoId { get; set; }
    public virtual Treino? Treino { get; set; }

    [Required]
    public int AlunoId { get; set; }
    public virtual Aluno? Aluno { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
    public DateTime Data { get; set; }
}
