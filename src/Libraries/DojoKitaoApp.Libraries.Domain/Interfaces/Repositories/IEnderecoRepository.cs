using DojoKitaoApp.Libraries.Domain.Entities;
using DojoKitaoApp.Libraries.Domain.Interfaces.Repositories.Model;

namespace DojoKitaoApp.Libraries.Domain.Interfaces.Repositories;

public interface IEnderecoRepository : IRepositoryModel<Endereco>
{
    public Task<int> AdicionarEnderecoAsync(Endereco endereco);
}
