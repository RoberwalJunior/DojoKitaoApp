using AutoMapper;
using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Aula;
using DojoKitaoApp.Libraries.Application.AutoMapper.Profiles;
using DojoKitaoApp.Libraries.Application.Interfaces;
using DojoKitaoApp.Libraries.Domain.Entities;
using DojoKitaoApp.Libraries.Domain.Interfaces.Repositories;

namespace DojoKitaoApp.Libraries.Application.Services;

public class AulaServiceApi : IAulaServiceApi
{
    private readonly IMapper mapper;
    private readonly IAulaRepository repository;

    public AulaServiceApi(IAulaRepository repository)
    {
        this.repository = repository;
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<AulaProfile>();
        });
        mapper = configuration.CreateMapper();
    }

    public async Task<IEnumerable<ReadAulaDto>> ListarTodasAsAulas()
    {
        var aulas = await repository.ListarTodosAsync();
        return mapper.Map<List<ReadAulaDto>>(aulas);
    }

    public async Task<IEnumerable<ReadAulaDto>> ListarTodasAsAulas(int idArteMarcial)
    {
        var aulas = await repository.ListarTodosAsync(aula => (int)aula.Treino!.ArteMarcial == idArteMarcial);
        return mapper.Map<List<ReadAulaDto>>(aulas);
    }

    public ReadAulaDto? RecuperarAulaPeloTreinoIdAlunoId(int treinoId, int alunoId)
    {
        var aula = repository.RecuperarPor(aula => aula.TreinoId == treinoId && aula.AlunoId == alunoId);
        return aula != null ? mapper.Map<ReadAulaDto>(aula) : null;
    }

    public ReadAulaDto? RecuperarAulaPelaData(string data)
    {
        var teste = DateTime.TryParse(data, out DateTime result);
        if (!teste) return null;
        var aula = repository.RecuperarPor(aula => aula.Data.Equals(result));
        return aula != null ? mapper.Map<ReadAulaDto>(aula) : null;
    }

    public async Task CriarNovaAula(CreateAulaDto aulaDto)
    {
        var aula = mapper.Map<Aula>(aulaDto);
        await repository.AdicionarAsync(aula);
    }
}
