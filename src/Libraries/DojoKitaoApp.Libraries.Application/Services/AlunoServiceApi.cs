using AutoMapper;
using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Aluno;
using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Matricula;
using DojoKitaoApp.Libraries.Application.AutoMapper.Profiles;
using DojoKitaoApp.Libraries.Application.Interfaces;
using DojoKitaoApp.Libraries.Domain.Entities;
using DojoKitaoApp.Libraries.Domain.Interfaces.Repositories;

namespace DojoKitaoApp.Libraries.Application.Services;

public class AlunoServiceApi : IAlunoServiceApi
{
    private readonly IMapper mapper;
    private readonly IAlunoRepository repository;

    public AlunoServiceApi(IAlunoRepository repository)
    {
        this.repository = repository;
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<AlunoProfile>();
            cfg.CreateMap<Matricula, ReadMatriculaDto>();
        });
        mapper = configuration.CreateMapper();
    }

    public async Task<IEnumerable<ReadAlunoDto>> ListarTodosOsAlunos()
    {
        var alunos = await repository.ListarTodosAsync();
        return mapper.Map<List<ReadAlunoDto>>(alunos);
    }

    public async Task<IEnumerable<ReadAlunoDto>> ListarTodosOsAlunosDaArteMarcial(int idArteMarcial)
    {
        var alunos = await repository.ListarTodosAsync(aluno => (int)aluno.Matricula!.ArteMarcial == idArteMarcial);
        return mapper.Map<List<ReadAlunoDto>>(alunos);
    }

    public ReadAlunoDto? RecuperarAlunoPeloId(int id)
    {
        var aluno = repository.RecuperarPor(aluno => aluno.Id == id);
        return aluno != null ? mapper.Map<ReadAlunoDto>(aluno) : null;
    }

    public ReadAlunoDto? RecuperarAlunoPeloNome(string nome)
    {
        var aluno = repository.RecuperarPor(aluno => aluno.Nome!.ToUpper().Equals(nome.ToUpper()));
        return aluno != null ? mapper.Map<ReadAlunoDto>(aluno) : null;
    }

    public ReadMatriculaDto? RecuperarMatriculaDoAluno(int id)
    {
        var aluno = repository.RecuperarPor(aluno => aluno.Id == id);
        return (aluno != null && aluno.Matricula != null)
            ? mapper.Map<ReadMatriculaDto>(aluno.Matricula) : null;
    }

    public async Task CriarNovoAluno(CreateAlunoDto alunoDto)
    {
        var aluno = mapper.Map<Aluno>(alunoDto);
        await repository.AdicionarAsync(aluno);
    }

    public async Task<bool> AtualizarAluno(int id, UpdateAlunoDto alunoDto)
    {
        var aluno = repository.RecuperarPor(x => x.Id == id);
        if (aluno == null) return false;
        mapper.Map(alunoDto, aluno);
        await repository.AtualizarAsync(aluno);
        return true;
    }

    public async Task<bool> RemoverAluno(int id)
    {
        var aluno = repository.RecuperarPor(x => x.Id == id);
        if (aluno == null) return false;
        await repository.RemoverAsync(aluno);
        return true;
    }
}
