using System.ComponentModel.DataAnnotations;

namespace DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Aula;

public class CreateAulaDto
{
    [Required(ErrorMessage = "{0} é obrigatório!")]
    [Display(Name = "Id do Treino")]
    public int TreinoId { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório!")]
    [Display(Name = "Id do Aluno")]
    public int AlunoId { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório!")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
    [Display(Name = "Data da Aula")]
    public DateTime Data { get; set; }
}
