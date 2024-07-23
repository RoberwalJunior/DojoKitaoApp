using System.Text;
using Newtonsoft.Json;
using DojoKitaoApp.Web.Interfaces.ServicesApi.Model;

namespace DojoKitaoApp.Web.Services.Api.Json;

public abstract class BaseServiceApi<T>(IHttpClientFactory factory, string nomeEndPoint) 
    : IModelServiceApi<T> where T : class
{
    protected readonly string ENDPOINT = nomeEndPoint;
    protected readonly HttpClient httpClient = factory.CreateClient("API");

    public async Task<ICollection<T>?> ListarAsync()
    {
        List<T>? lista = null;
        HttpResponseMessage response = await httpClient.GetAsync(ENDPOINT);

        if (response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            lista = JsonConvert.DeserializeObject<List<T>>(content);
        }

        return lista;
    }

    public async Task<T?> RecuperarPeloIdAsync(int id)
    {
        T? result = null;
        string url = $"{ENDPOINT}{id}";
        HttpResponseMessage response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            result = JsonConvert.DeserializeObject<T>(content);
        }
        return result;
    }

    public async Task<bool> CriarAsync(T modelo)
    {
        ByteArrayContent byteContent = SerializarObjeto(modelo);
        HttpResponseMessage responseMessage = await httpClient.PostAsync(ENDPOINT, byteContent);
        return responseMessage.IsSuccessStatusCode;
    }

    public async Task<bool> AlterarAsync(int id, T modelo)
    {
        ByteArrayContent byteContent = SerializarObjeto(modelo);
        string url = $"{ENDPOINT}{id}";
        HttpResponseMessage httpResponse = await httpClient.PutAsync(url, byteContent);
        return httpResponse.IsSuccessStatusCode;
    }

    public async Task<bool> DeletarAsync(int id)
    {
        string url = $"{ENDPOINT}{id}";
        HttpResponseMessage httpResponse = await httpClient.DeleteAsync(url);
        return httpResponse.IsSuccessStatusCode;
    }

    private static ByteArrayContent SerializarObjeto(T modelo)
    {
        string json = JsonConvert.SerializeObject(modelo);
        byte[] buffer = Encoding.UTF8.GetBytes(json);
        ByteArrayContent byteContent = new(buffer);
        byteContent.Headers.ContentType =
            new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        return byteContent;
    }
}
