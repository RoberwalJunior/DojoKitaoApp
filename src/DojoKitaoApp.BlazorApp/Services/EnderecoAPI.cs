using System.Net.Http.Json;
using DojoKitaoApp.BlazorApp.Dtos.Endereco;

namespace DojoKitaoApp.BlazorApp.Services;

public class EnderecoAPI(IHttpClientFactory factory)
{
    private readonly HttpClient _httpClient = factory.CreateClient("API");

    public async Task<ICollection<ReadEnderecoDto>?> ListarEnderecos()
    {
        ICollection<ReadEnderecoDto>? listaEnderecos = null;
        HttpResponseMessage response = await _httpClient.GetAsync("Enderecos");

        if (response.IsSuccessStatusCode)
        {
            listaEnderecos = await response.Content.ReadFromJsonAsync<ICollection<ReadEnderecoDto>>();
        }

        return listaEnderecos;
    }
}
