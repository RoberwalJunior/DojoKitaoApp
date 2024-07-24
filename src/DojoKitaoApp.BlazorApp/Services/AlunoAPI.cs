using System.Net.Http.Json;
using DojoKitaoApp.BlazorApp.Dtos.Aluno;

namespace DojoKitaoApp.BlazorApp.Services;

public class AlunoAPI(IHttpClientFactory factory)
{
    private readonly HttpClient _httpClient = factory.CreateClient("API");

    public async Task<ICollection<ReadAlunoDto>?> ListarAlunosAsync()
    {
        ICollection<ReadAlunoDto>? listaAlunos = null;
        HttpResponseMessage response = await _httpClient.GetAsync("Alunos");

        if (response.IsSuccessStatusCode)
        {
            listaAlunos = await response.Content.ReadFromJsonAsync<ICollection<ReadAlunoDto>>();
        }

        return listaAlunos;
    }
}
