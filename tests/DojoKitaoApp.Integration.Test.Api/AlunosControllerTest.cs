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
    public async Task POST_Retornar_Status_Ok_Quando_Cadastra_Aluno_Com_Endereco()
    {
        //Arrange
        var enderecoSemAluno = app.RecuperarEnderecoExistenteSemAluno();
        var alunoDto = new CreateAlunoDto()
        {
            EnderecoId = enderecoSemAluno.Id,
            Nome = "Jorge",
            Sobrenome = "Roberto",
            DataNascimento = new DateTime(2000, 6, 20)
        };
        using var client = app.CreateClient();

        //Act
        var result = await client.PostAsJsonAsync("/api/Alunos", alunoDto);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
    }

    [Fact]
    public async Task POST_Retorna_InternalServerError_Quando_Cadastra_Aluno_Sem_Endereco()
    {
        //Arrange
        var alunoDto = new CreateAlunoDto()
        {
            Nome = "Jorge",
            Sobrenome = "Roberto",
            DataNascimento = new DateTime(2000, 6, 20)
        };
        using var client = app.CreateClient();

        //Act
        var result = await client.PostAsJsonAsync("/api/Alunos", alunoDto);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(HttpStatusCode.InternalServerError, result.StatusCode);
    }

    [Fact]
    public async Task GET_Retorna_Lista_Alunos()
    {
        //Arrange
        using var client = app.CreateClient();

        //Act
        var alunosDtos = await client.GetFromJsonAsync<List<ReadAlunoDto>>($"/api/Alunos");

        //Assert
        Assert.NotNull(alunosDtos);
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
    public async Task GET_Retorna_Matriculas_Pelo_Id_Do_Aluno()
    {
        //Arrange
        var alunoExistente = app.RecuperarAlunoExistente();
        using var client = app.CreateClient();

        //Act
        var matriculasDto = await client.GetFromJsonAsync<List<ReadMatriculaDto>>($"/api/Alunos/{alunoExistente.Id}/Matricula");

        //Assert
        Assert.NotNull(matriculasDto);
    }

    [Fact]
    public async Task PUT_RetornaStatus_NoContent_Quando_Atualiza_Aluno_Com_Exito()
    {
        //Arrange
        var alunoExistente = app.RecuperarAlunoExistente();
        var alunoDto = new UpdateAlunoDto()
        {
            Nome = "Ricardo",
            Sobrenome = "Fixer",
            DataNascimento = new DateTime(1990, 3, 3)
        };
        using var client = app.CreateClient();

        //Act
        var result = await client.PutAsJsonAsync($"/api/Alunos/{alunoExistente.Id}", alunoDto);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
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
