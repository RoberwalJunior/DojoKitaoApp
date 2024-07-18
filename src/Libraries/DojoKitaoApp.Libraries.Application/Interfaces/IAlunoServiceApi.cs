using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Aluno;
using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Matricula;

namespace DojoKitaoApp.Libraries.Application.Interfaces;

public interface IAlunoServiceApi
{
    public Task<IEnumerable<ReadAlunoDto>> ListarTodosOsAlunos();
    public ReadAlunoDto? RecuperarAlunoPeloId(int id);
    public IEnumerable<ReadMatriculaDto>? RecuperarMatriculasDoAluno(int id);
    public Task CriarNovoAluno(CreateAlunoDto alunoDto);
    public Task<bool> AtualizarAluno(int id, UpdateAlunoDto alunoDto);
    public Task<bool> RemoverAluno(int id);
}
