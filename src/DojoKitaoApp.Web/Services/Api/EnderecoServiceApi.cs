using DojoKitaoApp.Web.Models;
using DojoKitaoApp.Web.Services.Api.Json;
using DojoKitaoApp.Web.Interfaces.ServicesApi;

namespace DojoKitaoApp.Web.Services.Api;

public class EnderecoServiceApi(IConfiguration configuration) 
    : BaseServiceApi<EnderecoViewModel>(configuration, "Enderecos/"), IEnderecoServiceApi
{
}
