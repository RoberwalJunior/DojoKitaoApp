using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Endereco;

namespace DojoKitaoApp.Libraries.Application.Interfaces;

public interface IEnderecoServiceApi
{
    public Task<IEnumerable<ReadEnderecoDto>> ListarTodosOsEnderecos();
    public ReadEnderecoDto? RecuperarEnderecoPeloId(int id);
    public Task<int> CriarNovoEndereco(CreateEnderecoDto enderecoDto);
    public Task<bool> AtualizarEndereco(int id, UpdateEnderecoDto enderecoDto);
}
