namespace DojoKitaoApp.Libraries.Domain.Interfaces.Repositories.Model;

public interface IRepositoryModel<T> : IDisposable where T : class
{
    public Task<IEnumerable<T>> ListarTodosAsync(Func<T, bool> condicao = null!);
    public T? RecuperarPor(Func<T, bool> condicao);
    public Task AdicionarAsync(T modelo);
    public Task AtualizarAsync(T modelo);
    public Task RemoverAsync(T modelo);
}
