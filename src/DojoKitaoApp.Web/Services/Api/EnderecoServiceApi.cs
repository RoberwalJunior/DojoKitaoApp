using DojoKitaoApp.Web.Models;
using DojoKitaoApp.Web.Services.Api.Json;
using DojoKitaoApp.Web.Interfaces.ServicesApi;

namespace DojoKitaoApp.Web.Services.Api;

public class EnderecoServiceApi(IHttpClientFactory factory)
    : BaseServiceApi<EnderecoViewModel>(factory, "Enderecos/"), IEnderecoServiceApi
{
    public async Task<int> CriarEnderecoAsync(EnderecoViewModel endereco)
    {
        int idEndereco = 0;
        ByteArrayContent byteContent = SerializarObjeto(endereco);
        HttpResponseMessage responseMessage = await httpClient.PostAsync(ENDPOINT, byteContent);

        if (responseMessage.IsSuccessStatusCode)
        {
            var result = await responseMessage.Content.ReadAsStringAsync();
            idEndereco = int.Parse(result);
        }

        return idEndereco;
    }
}
