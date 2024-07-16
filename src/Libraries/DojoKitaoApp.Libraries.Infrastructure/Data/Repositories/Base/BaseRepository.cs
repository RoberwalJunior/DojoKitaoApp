using DojoKitaoApp.Libraries.Domain.Interfaces.Repositories.Model;
using DojoKitaoApp.Libraries.Infrastructure.Data.Context;

namespace DojoKitaoApp.Libraries.Infrastructure.Data.Repositories.Base;

public abstract class BaseRepository<T>(AppDbContext context) : IRepositoryModel<T> where T : class
{
    private readonly AppDbContext context = context;

    public IEnumerable<T> ListarTodos()
    {
        return [.. context.Set<T>()];
    }

    public T? RecuperarPor(Func<T, bool> condicao)
    {
        return context.Set<T>().FirstOrDefault(condicao);
    }

    public void Adicionar(T modelo)
    {
        context.Set<T>().Add(modelo);
        context.SaveChanges();
    }

    public void Atualizar(T modelo)
    {
        context.Set<T>().Update(modelo);
        context.SaveChanges();
    }

    public void Remover(T modelo)
    {
        context.Set<T>().Remove(modelo);
        context.SaveChanges();
    }

    public void Dispose()
    {
        context.Dispose();
    }
}
