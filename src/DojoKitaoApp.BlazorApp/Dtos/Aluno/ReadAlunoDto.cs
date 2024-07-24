using DojoKitaoApp.BlazorApp.Dtos.Endereco;

namespace DojoKitaoApp.BlazorApp.Dtos.Aluno;

public class ReadAlunoDto
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Sobrenome { get; set; }
    public DateTime? DataNascimento { get; set; }
    public ReadEnderecoDto? Endereco { get; set; }
}
