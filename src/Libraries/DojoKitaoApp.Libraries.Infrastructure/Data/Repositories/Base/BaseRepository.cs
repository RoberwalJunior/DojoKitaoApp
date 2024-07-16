using Microsoft.EntityFrameworkCore;
using DojoKitaoApp.Libraries.Domain.Interfaces.Repositories.Model;
using DojoKitaoApp.Libraries.Infrastructure.Data.Context;

namespace DojoKitaoApp.Libraries.Infrastructure.Data.Repositories.Base;

public abstract class BaseRepository<T>(AppDbContext context) : IRepositoryModel<T> where T : class
{
    private readonly AppDbContext context = context;

    public async Task<IEnumerable<T>> ListarTodosAsync()
    {
        return await context.Set<T>().ToListAsync();
    }

    public T? RecuperarPor(Func<T, bool> condicao)
    {
        return context.Set<T>().FirstOrDefault(condicao);
    }

    public async Task AdicionarAsync(T modelo)
    {
        await context.Set<T>().AddAsync(modelo);
        await context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(T modelo)
    {
        context.Set<T>().Update(modelo);
        await context.SaveChangesAsync();
    }

    public async Task RemoverAsync(T modelo)
    {
        context.Set<T>().Remove(modelo);
        await context.SaveChangesAsync();
    }

    public void Dispose()
    {
        context.Dispose();
    }
}
