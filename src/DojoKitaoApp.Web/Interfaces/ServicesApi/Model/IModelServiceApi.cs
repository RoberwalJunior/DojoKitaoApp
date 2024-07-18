namespace DojoKitaoApp.Web.Interfaces.ServicesApi.Model;

public interface IModelServiceApi<T> where T : class
{
    Task<ICollection<T>?> ListarAsync();
    Task<T?> RecuperarPeloIdAsync(int id);
    Task<bool> CriarAsync(T modelo);
    Task<bool> AlterarAsync(int id, T modelo);
    Task<bool> DeletarAsync(int id);
}
