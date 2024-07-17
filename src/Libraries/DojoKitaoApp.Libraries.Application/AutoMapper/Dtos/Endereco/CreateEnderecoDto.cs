using System.ComponentModel.DataAnnotations;

namespace DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Endereco;

public class CreateEnderecoDto
{
    [StringLength(50, ErrorMessage = "Não pode ter mais que 50 caracteres.")]
    public string? Logradouro { get; set; }

    public int? Numero { get; set; }

    [StringLength(50, ErrorMessage = "Não pode ter mais que 50 caracteres.")]
    public string? Complemento { get; set; }

    [StringLength(10, ErrorMessage = "Não pode ter mais que 10 caracteres.")]
    public string? CEP { get; set; }
}
