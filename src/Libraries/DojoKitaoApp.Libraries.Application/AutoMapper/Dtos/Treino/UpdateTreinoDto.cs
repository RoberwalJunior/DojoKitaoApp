using System.ComponentModel.DataAnnotations;

namespace DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Treino;

public class UpdateTreinoDto
{
    [Display(Name = "Descrição")]
    public string? Descricao { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório!")]
    [Display(Name = "Arte Marcial")]
    [Range(0, 1)]
    public int ArteMarcial { get; set; }
}
