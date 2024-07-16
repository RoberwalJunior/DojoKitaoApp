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

    public IEnumerable<ReadMatriculaDto> ListarAsMatriculasDosAlunos()
    {
        var matriculas = repository.ListarTodos();
        return mapper.Map<List<ReadMatriculaDto>>(matriculas);
    }

    public IEnumerable<ReadMatriculaDto> ListarAsMatriculasDosAlunos(int idArteMarcial)
    {
        var matriculas = repository.ListarTodos();
        var matriculasSelecionadas = matriculas.Where(matricula => (int)matricula.ArteMarcial == idArteMarcial);
        return mapper.Map<List<ReadMatriculaDto>>(matriculasSelecionadas);
    }

    public void CriarNovaMatricula(CreateMatriculaDto matriculaDto)
    {
        var matricula = mapper.Map<Matricula>(matriculaDto);
        repository.Adicionar(matricula);
    }

    public bool AtualizarMatricula(int id, UpdateMatriculaDto matriculaDto)
    {
        var matricula = repository.RecuperarPor(x => x.Id == id);
        if (matricula == null) return false;
        mapper.Map(matriculaDto, matricula);
        repository.Atualizar(matricula);
        return true;
    }
}
