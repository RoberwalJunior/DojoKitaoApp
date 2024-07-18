using Microsoft.AspNetCore.Mvc.Testing;
using DojoKitaoApp.Libraries.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using DojoKitaoApp.Libraries.Infrastructure.Data.Context;

namespace DojoKitaoApp.Integration.Test.Api.Application;

public class DojoKitaoWebApplicationFactory : WebApplicationFactory<Program>
{
    private readonly AppDbContext context;

    public DojoKitaoWebApplicationFactory()
    {
        var scope = Services.CreateScope();
        context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    }

    public Endereco RecuperarEnderecoExistente()
    {
        var enderecoExistente = context.Enderecos.FirstOrDefault();
        enderecoExistente ??= RetornarNovoEndereco();
        return enderecoExistente;
    }

    public Endereco RecuperarEnderecoExistenteSemAluno()
    {
        var enderecoExistente = context.Enderecos.FirstOrDefault(endereco => endereco.Aluno == null);
        enderecoExistente ??= RetornarNovoEndereco();
        return enderecoExistente;
    }

    private Endereco RetornarNovoEndereco()
    {
        var novoEndereco = new Endereco()
        {
            Logradouro = "Rua das Flores",
            Numero = 120,
            CEP = "123345",
            Complemento = "Ap 15"
        };

        context.Add(novoEndereco);
        context.SaveChanges();
        return novoEndereco;
    }

    public Matricula RecuperarMatriculaExistente()
    {
        var matriculaExistente = context.Matriculas.FirstOrDefault();
        if (matriculaExistente == null)
        {
            var novoAluno = RetornarNovoAluno();
            matriculaExistente = new Matricula()
            {
                ArteMarcial = 0,
                AlunoId = novoAluno.Id
            };

            context.Add(matriculaExistente);
            context.SaveChanges();
        }
        return matriculaExistente;
    }

    public Aluno RecuperarAlunoExistente()
    {
        var alunoExistente = context.Alunos.FirstOrDefault();
        return alunoExistente ?? RetornarNovoAluno();
    }

    public Aluno RetornarNovoAluno()
    {
        var enderecoSemAluno = RecuperarEnderecoExistenteSemAluno();
        var aluno = new Aluno()
        {
            EnderecoId = enderecoSemAluno.Id,
            Nome = "Maria",
            Sobrenome = "Campos",
            DataNascimento = new DateTime(1990, 2, 2)
        };

        context.Add(aluno);
        context.SaveChanges();
        return aluno;
    }

    public Treino RecuperaTreinoExistente()
    {
        var treinoExistente = context.Treinos.FirstOrDefault();
        if (treinoExistente == null)
        {
            treinoExistente = new Treino()
            {
                Descricao = "Descrição teste",
                ArteMarcial = 0
            };

            context.Add(treinoExistente);
            context.SaveChanges();
        }
        return treinoExistente;
    }

    public Aula RecuperaAulaExistente()
    {
        var aulaExistente = context.Aulas.FirstOrDefault();
        if (aulaExistente == null)
        {
            var alunoExistente = RetornarNovoAluno();
            var treinoExistente = RecuperaTreinoExistente();
            aulaExistente = new Aula()
            {
                Aluno = alunoExistente,
                AlunoId = alunoExistente.Id,
                Treino = treinoExistente,
                TreinoId = treinoExistente.Id,
                Data = DateTime.Now
            };

            context.Add(aulaExistente);
            context.SaveChanges();
        }
        return aulaExistente;
    }
}
