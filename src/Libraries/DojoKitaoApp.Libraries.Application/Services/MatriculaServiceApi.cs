using AutoMapper;
using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Matricula;
using DojoKitaoApp.Libraries.Application.AutoMapper.Profiles;
using DojoKitaoApp.Libraries.Application.Interfaces;
using DojoKitaoApp.Libraries.Domain.Entities;
using DojoKitaoApp.Libraries.Domain.Interfaces.Repositories;

namespace DojoKitaoApp.Libraries.Application.Services;

public class MatriculaServiceApi : IMatriculaServiceApi
{
    private readonly IMapper mapper;
    private readonly IMatriculaRepository repository;

    public MatriculaServiceApi(IMatriculaRepository repository)
    {
        this.repository = repository;
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MatriculaProfile>();
        });
        mapper = configuration.CreateMapper();
    }

    public async Task<IEnumerable<ReadMatriculaDto>> ListarAsMatriculasDosAlunos()
    {
        var matriculas = await repository.ListarTodosAsync();
        return mapper.Map<List<ReadMatriculaDto>>(matriculas);
    }

    public ReadMatriculaDto? RecuperarMatriculaPeloId(int id)
    {
        var matricula = repository.RecuperarPor(matricula => matricula.Id == id);
        return matricula != null ? mapper.Map<ReadMatriculaDto>(matricula) : null;
    }

    public async Task CriarNovaMatricula(CreateMatriculaDto matriculaDto)
    {
        var matricula = mapper.Map<Matricula>(matriculaDto);
        await repository.AdicionarAsync(matricula);
    }

    public async Task<bool> AtualizarMatricula(int id, UpdateMatriculaDto matriculaDto)
    {
        var matricula = repository.RecuperarPor(x => x.Id == id);
        if (matricula == null) return false;
        mapper.Map(matriculaDto, matricula);
        await repository.AtualizarAsync(matricula);
        return true;
    }

    public async Task<bool> RemoverMatricula(int id)
    {
        var matricula = repository.RecuperarPor(x => x.Id == id);
        if (matricula == null) return false;
        await repository.RemoverAsync(matricula);
        return true;
    }
}
