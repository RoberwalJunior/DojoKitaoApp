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

    public int RecuperarIdMatriculaExistente()
    {
        var matriculaExistente = context.Matriculas.FirstOrDefault(matricula => matricula.Aluno == null);
        if (matriculaExistente == null)
        {
            matriculaExistente = new Matricula()
            {
                Endereco = "Rua teste",
                ArteMarcial = 0
            };

            context.Add(matriculaExistente);
            context.SaveChanges();
        }
        return matriculaExistente.Id;
    }

    public Aluno RecuperarAlunoExistente()
    {
        var alunoExistente = context.Alunos.FirstOrDefault();
        if (alunoExistente == null)
        {
            var idMatriculaExistente = RecuperarIdMatriculaExistente();
            alunoExistente = new Aluno()
            {
                Nome = "Aluno Teste",
                MatriculaId = idMatriculaExistente
            };

            context.Add(alunoExistente);
            context.SaveChanges();
        }
        return alunoExistente;
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
            var alunoExistente = RecuperarAlunoExistente();
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
