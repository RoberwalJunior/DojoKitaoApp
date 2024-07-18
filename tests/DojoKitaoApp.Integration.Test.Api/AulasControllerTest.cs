using DojoKitaoApp.Integration.Test.Api.Application;
using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Aula;
using System.Net;
using System.Net.Http.Json;

namespace DojoKitaoApp.Integration.Test.Api;

public class AulasControllerTest(DojoKitaoWebApplicationFactory app)
    : IClassFixture<DojoKitaoWebApplicationFactory>
{
    private readonly DojoKitaoWebApplicationFactory app = app;

    [Fact]
    public async Task POST_Retornar_Status_Ok_Quando_Cadastra_Aula()
    {
        //Arrange
        var alunoExistente = app.RetornarNovoAluno();
        var treinoExistente = app.RecuperaTreinoExistente();
        var aulaDto = new CreateAulaDto()
        {
            AlunoId = alunoExistente.Id,
            TreinoId = treinoExistente.Id,
            Data = DateTime.Now
        };
        using var client = app.CreateClient();

        //Act
        var result = await client.PostAsJsonAsync("/api/Aulas", aulaDto);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
    }

    [Fact]
    public async Task GET_Retorna_Lista_Aulas()
    {
        //Arrange
        using var client = app.CreateClient();

        //Act
        var aulasDto = await client.GetFromJsonAsync<List<ReadAulaDto>>($"/api/Aulas");

        //Assert
        Assert.NotNull(aulasDto);
    }

    [Fact]
    public async Task GET_Retorna_Aula_Pelo_TreinoId_AlunoId()
    {
        //Arrange
        var aulaExistente = app.RecuperaAulaExistente();
        using var client = app.CreateClient();

        //Act
        var alunoDto = await client.GetFromJsonAsync<ReadAulaDto>($"/api/Aulas/{aulaExistente.TreinoId}/{aulaExistente.AlunoId}");

        //Assert
        Assert.NotNull(alunoDto);
        Assert.Equal(aulaExistente.TreinoId, alunoDto.TreinoId);
        Assert.Equal(aulaExistente.AlunoId, alunoDto.AlunoId);
    }
}
