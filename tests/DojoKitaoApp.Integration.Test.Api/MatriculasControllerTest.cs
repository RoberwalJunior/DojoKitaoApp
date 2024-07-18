using System.Net;
using System.Net.Http.Json;
using DojoKitaoApp.Integration.Test.Api.Application;
using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Matricula;

namespace DojoKitaoApp.Integration.Test.Api;

public class MatriculasControllerTest(DojoKitaoWebApplicationFactory app)
    : IClassFixture<DojoKitaoWebApplicationFactory>
{
    private readonly DojoKitaoWebApplicationFactory app = app;

    [Fact]
    public async Task GET_Retorna_Lista_Matriculas()
    {
        //Arrange
        using var client = app.CreateClient();

        //Act
        var matriculasDto = await client.GetFromJsonAsync<List<ReadMatriculaDto>>($"/api/Matriculas");

        //Assert
        Assert.NotNull(matriculasDto);
    }

    [Fact]
    public async Task GET_Retorna_Matricula_Pelo_Id_Existente()
    {
        //Arrange
        var matriculaExistente = app.RecuperarMatriculaExistente();
        using var client = app.CreateClient();

        //Act
        var matriculaDto = await client.GetFromJsonAsync<ReadMatriculaDto>($"/api/Matriculas/{matriculaExistente.Id}");

        //Assert
        Assert.NotNull(matriculaDto);
        Assert.Equal(matriculaExistente.Id, matriculaDto.Id);
        Assert.Equal(matriculaExistente.ArteMarcial.ToString(), matriculaDto.ArteMarcial);
    }

    [Theory]
    [InlineData(1, HttpStatusCode.OK)]
    [InlineData(10, HttpStatusCode.BadRequest)]
    public async Task POST_Retorna_Status_Correspondente_Quando_Cadastra_Matricula(int idArteMarcial, HttpStatusCode statusCode)
    {
        //Arrange
        var alunoExistente = app.RecuperarAlunoExistente();
        var matriculaDto = new CreateMatriculaDto()
        {
            AlunoId = alunoExistente.Id,
            ArteMarcial = idArteMarcial
        };
        using var client = app.CreateClient();

        //Act
        var result = await client.PostAsJsonAsync("/api/Matriculas", matriculaDto);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(statusCode, result.StatusCode);
    }

    [Theory]
    [InlineData(1, HttpStatusCode.NoContent)]
    [InlineData(10, HttpStatusCode.BadRequest)]
    public async Task PUT_Retorna_Status_Correspondente_Quando_Atualiza_Matricula(int idArteMarcial, HttpStatusCode statusCode)
    {
        //Arrange
        var matriculaExistente = app.RecuperarMatriculaExistente();
        var novoAluno = app.RetornarNovoAluno();
        using var client = app.CreateClient();
        var matriculaDto = new UpdateMatriculaDto()
        {
            AlunoId = novoAluno.Id,
            ArteMarcial = idArteMarcial
        };

        //Act
        var result = await client.PutAsJsonAsync($"/api/Matriculas/{matriculaExistente.Id}", matriculaDto);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(statusCode, result.StatusCode);
    }

    [Fact]
    public async Task DELETE_Retorna_Status_NoContent_Quando_Exclui_Matricula_Com_Exito()
    {
        //Arrange
        var matriculaExistente = app.RecuperarMatriculaExistente();
        using var client = app.CreateClient();

        //Act
        var result = await client.DeleteAsync($"/api/Matriculas/{matriculaExistente.Id}");

        //Assert
        Assert.NotNull(result);
        Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
    }
}
