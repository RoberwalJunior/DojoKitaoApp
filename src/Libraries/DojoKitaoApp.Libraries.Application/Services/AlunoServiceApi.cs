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

    public IEnumerable<ReadAlunoDto> ListarTodosOsAlunos()
    {
        var alunos = repository.ListarTodos();
        return mapper.Map<List<ReadAlunoDto>>(alunos);
    }

    public IEnumerable<ReadAlunoDto> ListarTodosOsAlunosDaArteMarcial(int idArteMarcial)
    {
        var alunos = repository.ListarTodos();
        var alunosSelecionados = alunos.Where(aluno => (int)aluno.Matricula!.ArteMarcial == idArteMarcial);
        return mapper.Map<List<ReadAlunoDto>>(alunosSelecionados);
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

    public void CriarNovoAluno(CreateAlunoDto alunoDto)
    {
        var aluno = mapper.Map<Aluno>(alunoDto);
        repository.Adicionar(aluno);
    }

    public bool AtualizarAluno(int id, UpdateAlunoDto alunoDto)
    {
        var aluno = repository.RecuperarPor(x => x.Id == id);
        if (aluno == null) return false;
        mapper.Map(alunoDto, aluno);
        repository.Atualizar(aluno);
        return true;
    }

    public bool RemoverAluno(int id)
    {
        var aluno = repository.RecuperarPor(x => x.Id == id);
        if (aluno == null) return false;
        repository.Remover(aluno);
        return true;
    }
}
