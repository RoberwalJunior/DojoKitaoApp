using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Aula;

namespace DojoKitaoApp.Libraries.Application.Interfaces;

public interface IAulaServiceApi
{
    public Task<IEnumerable<ReadAulaDto>> ListarTodasAsAulas();
    public ReadAulaDto? RecuperarAulaPeloTreinoIdAlunoId(int treinoId, int alunoId);
    public Task CriarNovaAula(CreateAulaDto aulaDto);
}
