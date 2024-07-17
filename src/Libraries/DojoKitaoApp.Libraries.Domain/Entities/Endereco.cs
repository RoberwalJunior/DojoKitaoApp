using System.ComponentModel.DataAnnotations;

namespace DojoKitaoApp.Libraries.Domain.Entities;

public class Endereco
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string? Logradouro { get; set; }

    public int? Numero { get; set; }

    [MaxLength(50)]
    public string? Complemento { get; set; }

    [MaxLength(10)]
    public string? CEP { get; set; }

    public virtual Aluno? Aluno { get; set; }
}
