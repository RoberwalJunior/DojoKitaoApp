using System.ComponentModel.DataAnnotations;

namespace DojoKitaoApp.Libraries.Domain.Entities;

public class Aluno
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Nome { get; set; }

    [Required]
    [MaxLength(150)]
    public string? Sobrenome { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
    public DateTime? DataNascimento { get; set; }

    [Required]
    public int EnderecoId { get; set; }
    public virtual Endereco? Endereco { get; set; }

    public virtual ICollection<Matricula>? Matriculas { get; set; }
    public virtual ICollection<Aula>? Aulas { get; set; }
}
