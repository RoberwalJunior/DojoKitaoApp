using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Treino;

public class UpdateTreinoDto
{
    [DisplayName("Descrição")]
    public string? Descricao { get; set; }

    [Required(ErrorMessage = "Arte Marcial é obrigatório!")]
    [Range(0, 1)]
    public int ArteMarcial { get; set; }
}
