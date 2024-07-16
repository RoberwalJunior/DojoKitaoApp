using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Matricula;

namespace DojoKitaoApp.Libraries.Application.Interfaces;

public interface IMatriculaServiceApi
{
    public Task<IEnumerable<ReadMatriculaDto>> ListarAsMatriculasDosAlunos();
    public Task<IEnumerable<ReadMatriculaDto>> ListarAsMatriculasDosAlunos(int idArteMarcial);
    public Task CriarNovaMatricula(CreateMatriculaDto matriculaDto);
    public Task<bool> AtualizarMatricula(int id, UpdateMatriculaDto matriculaDto);
}
