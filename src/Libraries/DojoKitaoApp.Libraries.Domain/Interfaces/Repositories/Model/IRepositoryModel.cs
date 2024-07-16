namespace DojoKitaoApp.Libraries.Domain.Interfaces.Repositories.Model;

public interface IRepositoryModel<T> : IDisposable where T : class
{
    public IEnumerable<T> ListarTodos();
    public T? RecuperarPor(Func<T, bool> condicao);
    public void Adicionar(T modelo);
    public void Atualizar(T modelo);
    public void Remover(T modelo);
}
