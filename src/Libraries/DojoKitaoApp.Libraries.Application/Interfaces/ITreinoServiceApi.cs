using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Treino;

namespace DojoKitaoApp.Libraries.Application.Interfaces;

public interface ITreinoServiceApi
{
    public Task<IEnumerable<ReadTreinoDto>> ListarTodosOsTreinos();
    public ReadTreinoDto? RecuperarTreinoPeloId(int id);
    public Task CriarNovoTreino(CreateTreinoDto treinoDto);
    public Task<bool> AtualizarTreino(int id, UpdateTreinoDto treinoDto);
    public Task<bool> RemoverTreino(int id);
}
