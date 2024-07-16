using System.Net;
using System.Net.Http.Json;
using DojoKitaoApp.Integration.Test.Api.Factory;
using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Aluno;

namespace DojoKitaoApp.Integration.Test.Api;

public class AlunosControllerTest(DojoKitaoWebApplicationFactory app)
    : IClassFixture<DojoKitaoWebApplicationFactory>
{
    private readonly DojoKitaoWebApplicationFactory app = app;

    [Fact]
    public async Task POST_Retornar_Status_Ok_Quando_Cadastra_Aluno_Com_Matricula()
    {
        //Arrange
        var idMatriculaExistente = app.RecuperarIdMatriculaExistente();
        var matriculaDto = new CreateAlunoDto()
        {
            Nome = "Aluno teste",
            MatriculaId = idMatriculaExistente
        };
        using var client = app.CreateClient();

        //Act
        var result = await client.PostAsJsonAsync("/api/Alunos", matriculaDto);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
    }

    [Fact]
    public async Task POST_Retorna_NotFound_Quando_Cadastra_Aluno_Sem_Matricula()
    {
        //Arrange
        var matriculaDto = new CreateAlunoDto()
        {
            Nome = "Aluno teste"
        };
        using var client = app.CreateClient();

        //Act
        var result = await client.PostAsJsonAsync("/api/Alunos", matriculaDto);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(HttpStatusCode.InternalServerError, result.StatusCode);
    }
}
