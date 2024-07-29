using DojoKitaoApp.Web.Models;
using DojoKitaoApp.Web.Interfaces.ServicesApi.Model;

namespace DojoKitaoApp.Web.Interfaces.ServicesApi;

public interface IEnderecoServiceApi : IModelServiceApi<EnderecoViewModel>
{
    Task<int> CriarEnderecoAsync(EnderecoViewModel endereco);
}
