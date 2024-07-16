using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Matricula;

namespace DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Aluno;

public class ReadAlunoDto
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public ReadMatriculaDto? Matricula { get; set; }
}
