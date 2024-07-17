using AutoMapper;
using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Treino;
using DojoKitaoApp.Libraries.Application.AutoMapper.Profiles;
using DojoKitaoApp.Libraries.Application.Interfaces;
using DojoKitaoApp.Libraries.Domain.Entities;
using DojoKitaoApp.Libraries.Domain.Interfaces.Repositories;

namespace DojoKitaoApp.Libraries.Application.Services;

public class TreinoServiceApi : ITreinoServiceApi
{
    private readonly IMapper mapper;
    private readonly ITreinoRepository repository;

    public TreinoServiceApi(ITreinoRepository repository)
    {
        this.repository = repository;
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<TreinoProfile>();
        });
        mapper = configuration.CreateMapper();
    }

    public async Task<IEnumerable<ReadTreinoDto>> ListarTodosOsTreinos()
    {
        var treinos = await repository.ListarTodosAsync();
        return mapper.Map<List<ReadTreinoDto>>(treinos);
    }

    public async Task<IEnumerable<ReadTreinoDto>> ListarTodosOsTreinos(int idArteMarcial)
    {
        var treinos = await repository.ListarTodosAsync(treino => (int)treino.ArteMarcial == idArteMarcial);
        return mapper.Map<List<ReadTreinoDto>>(treinos);
    }

    public ReadTreinoDto? RecuperarTreinoPeloId(int id)
    {
        var treino = repository.RecuperarPor(treino => treino.Id == id);
        return treino != null ? mapper.Map<ReadTreinoDto>(treino) : null;
    }

    public async Task CriarNovoTreino(CreateTreinoDto treinoDto)
    {
        var treino = mapper.Map<Treino>(treinoDto);
        await repository.AdicionarAsync(treino);
    }

    public async Task<bool> AtualizarTreino(int id, UpdateTreinoDto treinoDto)
    {
        var treino = repository.RecuperarPor(x => x.Id == id);
        if (treino == null) return false;
        mapper.Map(treinoDto, treino);
        await repository.AtualizarAsync(treino);
        return true;
    }

    public async Task<bool> RemoverTreino(int id)
    {
        var treino = repository.RecuperarPor(x => x.Id == id);
        if (treino == null) return false;
        await repository.RemoverAsync(treino);
        return true;
    }
}
