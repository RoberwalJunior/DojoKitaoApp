using Microsoft.AspNetCore.Mvc.Testing;
using DojoKitaoApp.Libraries.Domain.Entities;
using DojoKitaoApp.Libraries.Infrastructure.Data.Context;
using Microsoft.Extensions.DependencyInjection;

namespace DojoKitaoApp.Integration.Test.Api.Factory;

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
}
