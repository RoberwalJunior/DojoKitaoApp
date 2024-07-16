using System.Net;
using System.Net.Http.Json;
using DojoKitaoApp.Integration.Test.Api.Application;
using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Aluno;
using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Matricula;

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
    public async Task POST_Retorna_InternalServerError_Quando_Cadastra_Aluno_Sem_Matricula()
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

    [Fact]
    public async Task GET_Retorna_Aluno_Pelo_Id()
    {
        //Arrange
        var alunoExistente = app.RecuperarAlunoExistente();
        using var client = app.CreateClient();

        //Act
        var alunoDto = await client.GetFromJsonAsync<ReadAlunoDto>($"/api/Alunos/{alunoExistente.Id}");

        //Assert
        Assert.NotNull(alunoDto);
        Assert.Equal(alunoExistente.Id, alunoDto.Id);
        Assert.Equal(alunoExistente.Nome, alunoDto.Nome);
    }

    [Fact]
    public async Task GET_Retorna_Status_NotFound_Quando_For_Recuperar_Aluno_Pelo_Id_Inexistente()
    {
        //Arrange
        int idAlunoInexistente = 9999;
        using var client = app.CreateClient();

        //Act + Assert
        await Assert.ThrowsAsync<HttpRequestException>(async () =>
        {
            var alunoDto = await client.GetFromJsonAsync<ReadAlunoDto>($"/api/Alunos/{idAlunoInexistente}");
        });
    }

    [Fact]
    public async Task GET_Retorna_Matricula_Pelo_Id_Do_Aluno()
    {
        //Arrange
        var alunoExistente = app.RecuperarAlunoExistente();
        var matricula = alunoExistente.Matricula!;
        using var client = app.CreateClient();

        //Act
        var matriculaDto = await client.GetFromJsonAsync<ReadMatriculaDto>($"/api/Alunos/{alunoExistente.Id}/Matricula");

        //Assert
        Assert.NotNull(matriculaDto);
        Assert.Equal(matricula.Id, matriculaDto.Id);
        Assert.Equal(matricula.Endereco, matriculaDto.Endereco);
        Assert.Equal(matricula.ArteMarcial.ToString(), matriculaDto.ArteMarcial);
    }

    [Fact]
    public async Task DELETE_Retorna_Status_NoContent_Quando_Exclui_Aluno_Com_Exito()
    {
        //Arrange
        var alunoExistente = app.RecuperarAlunoExistente();
        using var client = app.CreateClient();

        //Act
        var result = await client.DeleteAsync($"/api/Alunos/{alunoExistente.Id}");

        //Assert
        Assert.NotNull(result);
        Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
    }
}
