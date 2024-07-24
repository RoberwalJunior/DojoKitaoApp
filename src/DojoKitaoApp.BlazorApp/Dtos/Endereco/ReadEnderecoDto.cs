namespace DojoKitaoApp.BlazorApp.Dtos.Endereco;

public class ReadEnderecoDto
{
    public int Id { get; set; }
    public string? Logradouro { get; set; }
    public int? Numero { get; set; }
    public string? Complemento { get; set; }
    public string? CEP { get; set; }
}
