using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Aluno;
using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Matricula;

namespace DojoKitaoApp.Libraries.Application.Interfaces;

public interface IAlunoServiceApi
{
    public IEnumerable<ReadAlunoDto> ListarTodosOsAlunos();
    public IEnumerable<ReadAlunoDto> ListarTodosOsAlunosDaArteMarcial(int idArteMarcial);
    public ReadAlunoDto? RecuperarAlunoPeloId(int id);
    public ReadAlunoDto? RecuperarAlunoPeloNome(string nome);
    public ReadMatriculaDto? RecuperarMatriculaDoAluno(int id);
    public void CriarNovoAluno(CreateAlunoDto alunoDto);
    public bool AtualizarAluno(int id, UpdateAlunoDto alunoDto);
    public bool RemoverAluno(int id);
}
