using System.Net;
using System.Net.Http.Json;
using DojoKitaoApp.Integration.Test.Api.Factory;
using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Matricula;

namespace DojoKitaoApp.Integration.Test.Api;

public class MatriculasControllerTest(DojoKitaoWebApplicationFactory app)
    : IClassFixture<DojoKitaoWebApplicationFactory>
{
    private readonly DojoKitaoWebApplicationFactory app = app;

    [Fact]
    public async Task POST_Cadastra_Matricula()
    {
        //Arrange
        var matriculaDto = new CreateMatriculaDto()
        {
            Endereco = "Rua teste",
            ArteMarcial = 0
        };
        using var client = app.CreateClient();

        //Act
        var result = await client.PostAsJsonAsync("/api/Matriculas", matriculaDto);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
    }

    [Fact]
    public async Task PUT_Atualiza_Matricula()
    {
        //Arrange
        var idMatriculaExistente = app.RecuperarIdMatriculaExistente();
        using var client = app.CreateClient();
        var matriculaDto = new UpdateMatriculaDto()
        {
            Endereco = "Endereço atualizado"
        };

        //Act
        var result = await client.PutAsJsonAsync($"/api/Matriculas/{idMatriculaExistente}", matriculaDto);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
    }
}
