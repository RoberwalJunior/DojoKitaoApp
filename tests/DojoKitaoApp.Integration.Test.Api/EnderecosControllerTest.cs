using System.Net;
using System.Net.Http.Json;
using DojoKitaoApp.Integration.Test.Api.Application;
using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Endereco;

namespace DojoKitaoApp.Integration.Test.Api;

public class EnderecosControllerTest(DojoKitaoWebApplicationFactory app)
    : IClassFixture<DojoKitaoWebApplicationFactory>
{
    private readonly DojoKitaoWebApplicationFactory app = app;

    [Fact]
    public async Task POST_Retornar_Status_Ok_Quando_Cadastra_Endereco_Com_Exito()
    {
        //Arrange
        var enderecoDto = new CreateEnderecoDto()
        {
            Logradouro = "Rua Mariposa",
            Numero = 200,
            Complemento = "n/a",
            CEP = "5432111"
        };
        using var client = app.CreateClient();

        //act
        var result = await client.PostAsJsonAsync("/api/Enderecos", enderecoDto);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
    }

    [Fact]
    public async Task POST_Retornar_IdEndereco_Quando_Cadastra_Endereco_Com_Exito()
    {
        //Arrange
        var enderecoDto = new CreateEnderecoDto()
        {
            Logradouro = "Rua Mariposa",
            Numero = 200,
            Complemento = "n/a",
            CEP = "5432111"
        };
        using var client = app.CreateClient();

        //act
        var result = await client.PostAsJsonAsync("/api/Enderecos", enderecoDto);
        int idEndereco = int.Parse(await result.Content.ReadAsStringAsync());

        //Assert
        Assert.NotNull(result);
        Assert.True(idEndereco > 0);
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
    }

    [Fact]
    public async Task GET_Retorna_Lista_Enderecos()
    {
        //Arrange
        using var client = app.CreateClient();

        //Act
        var enderecosDto = await client.GetFromJsonAsync<List<ReadEnderecoDto>>($"/api/Enderecos");

        //Assert
        Assert.NotNull(enderecosDto);
    }

    [Fact]
    public async Task GET_Retorna_Endereco_Pelo_Id()
    {
        //Arrange
        var enderecoExistente = app.RecuperarEnderecoExistente();
        using var client = app.CreateClient();

        //Act
        var enderecoDto = await client.GetFromJsonAsync<ReadEnderecoDto>($"/api/Enderecos/{enderecoExistente.Id}");

        //Assert
        Assert.NotNull(enderecoDto);
        Assert.Equal(enderecoExistente.Id, enderecoDto.Id);
        Assert.Equal(enderecoExistente.Logradouro, enderecoDto.Logradouro);
        Assert.Equal(enderecoExistente.Numero, enderecoDto.Numero);
        Assert.Equal(enderecoExistente.Complemento, enderecoDto.Complemento);
        Assert.Equal(enderecoExistente.CEP, enderecoDto.CEP);
    }

    [Fact]
    public async Task PUT_RetornaStatus_NoContent_Quando_Atualiza_Endereco_Com_Exito()
    {
        //Arrange
        var enderecoExistente = app.RecuperarEnderecoExistente();
        var enderecoDto = new UpdateEnderecoDto()
        {
            Logradouro = "Rua das Maravilhas",
            Numero = 120,
            CEP = "333333",
            Complemento = "Casa 66"
        };
        using var client = app.CreateClient();

        //Act
        var result = await client.PutAsJsonAsync($"/api/Enderecos/{enderecoExistente.Id}", enderecoDto);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
    }
}
