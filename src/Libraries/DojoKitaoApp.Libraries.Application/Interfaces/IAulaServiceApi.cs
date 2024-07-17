using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Aula;

namespace DojoKitaoApp.Libraries.Application.Interfaces;

public interface IAulaServiceApi
{
    public Task<IEnumerable<ReadAulaDto>> ListarTodasAsAulas();
    public Task<IEnumerable<ReadAulaDto>> ListarTodasAsAulas(int idArteMarcial);
    public ReadAulaDto? RecuperarAulaPeloTreinoIdAlunoId(int treinoId, int alunoId);
    public ReadAulaDto? RecuperarAulaPelaData(string data);
    public Task CriarNovaAula(CreateAulaDto aulaDto);
}
