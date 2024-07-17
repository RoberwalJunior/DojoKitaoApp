using System.Net;
using System.Net.Http.Json;
using DojoKitaoApp.Integration.Test.Api.Application;
using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Treino;

namespace DojoKitaoApp.Integration.Test.Api;

public class TreinosControllerTest(DojoKitaoWebApplicationFactory app)
    : IClassFixture<DojoKitaoWebApplicationFactory>
{
    private readonly DojoKitaoWebApplicationFactory app = app;

    [Theory]
    [InlineData(1, HttpStatusCode.OK)]
    [InlineData(10, HttpStatusCode.BadRequest)]
    public async Task POST_Retorna_Status_Correspondente_Quando_Cadastra_Treino(int idArteMarcial, HttpStatusCode statusCode)
    {
        //Arrange
        var treinoDto = new CreateTreinoDto()
        {
            Descricao = "Treino de Soco",
            ArteMarcial = idArteMarcial
        };
        using var client = app.CreateClient();

        //Act
        var result = await client.PostAsJsonAsync("/api/Treinos", treinoDto);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(statusCode, result.StatusCode);
    }

    [Fact]
    public async Task GET_Retorna_Lista_Treinos()
    {
        //Arrange
        using var client = app.CreateClient();

        //Act
        var treinosDtos = await client.GetFromJsonAsync<List<ReadTreinoDto>>($"/api/Treinos");

        //Assert
        Assert.NotNull(treinosDtos);
    }

    [Fact]
    public async Task GET_Retorna_Treino_Pelo_Id_Existente()
    {
        //Arrange
        var treinoExistente = app.RecuperaTreinoExistente();
        using var client = app.CreateClient();

        //Act
        var treinoDto = await client.GetFromJsonAsync<ReadTreinoDto>($"/api/Treinos/{treinoExistente.Id}");

        //Assert
        Assert.NotNull(treinoDto);
        Assert.Equal(treinoExistente.Id, treinoDto.Id);
        Assert.Equal(treinoExistente.Descricao, treinoDto.Descricao);
        Assert.Equal(treinoExistente.ArteMarcial.ToString(), treinoDto.ArteMarcial);
    }

    [Theory]
    [InlineData(1, HttpStatusCode.NoContent)]
    [InlineData(10, HttpStatusCode.BadRequest)]
    public async Task PUT_Retorna_Status_Correspodente_Quando_Atualiza_Treino(int idArteMarcial, HttpStatusCode statusCode)
    {
        //Arrange
        var treinoExistente = app.RecuperaTreinoExistente();
        using var client = app.CreateClient();
        var treinoDto = new UpdateTreinoDto()
        {
            Descricao = "descricao Atualizado",
            ArteMarcial = idArteMarcial
        };

        //Act
        var result = await client.PutAsJsonAsync($"/api/Treinos/{treinoExistente.Id}", treinoDto);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(statusCode, result.StatusCode);
    }

    [Fact]
    public async Task DELETE_Retorna_Status_NoContent_Quando_Exclui_Treino_Com_Exito()
    {
        //Arrange
        var treinoExistente = app.RecuperaTreinoExistente();
        using var client = app.CreateClient();

        //Act
        var result = await client.DeleteAsync($"/api/Treinos/{treinoExistente.Id}");

        //Assert
        Assert.NotNull(result);
        Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
    }
}
