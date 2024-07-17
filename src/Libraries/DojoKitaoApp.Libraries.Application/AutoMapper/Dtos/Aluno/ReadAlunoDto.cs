using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Endereco;

namespace DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Aluno;

public class ReadAlunoDto
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Sobrenome { get; set; }
    public DateTime? DataNascimento { get; set; }
    public ReadEnderecoDto? Endereco { get; set; }
}
