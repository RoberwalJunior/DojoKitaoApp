namespace DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Endereco;

public class ReadEnderecoDto
{
    public int Id { get; set; }
    public int AlunoId { get; set; }
    public string? Logradouro { get; set; }
    public int? Numero { get; set; }
    public string? Complemento { get; set; }
    public string? CEP { get; set; }
}
