using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Matricula;

namespace DojoKitaoApp.Libraries.Application.Interfaces;

public interface IMatriculaServiceApi
{
    public Task<IEnumerable<ReadMatriculaDto>> ListarAsMatriculasDosAlunos();
    public ReadMatriculaDto? RecuperarMatriculaPeloId(int id);
    public Task CriarNovaMatricula(CreateMatriculaDto matriculaDto);
    public Task<bool> AtualizarMatricula(int id, UpdateMatriculaDto matriculaDto);
    public Task<bool> RemoverMatricula(int id);
}
