using System.ComponentModel.DataAnnotations;

namespace DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Aula;

public class UpdateAulaDto
{
    [Required]
    public int TreinoId { get; set; }

    [Required]
    public int AlunoId { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime Data { get; set; }
}
