using AutoMapper;
using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Endereco;
using DojoKitaoApp.Libraries.Application.AutoMapper.Profiles;
using DojoKitaoApp.Libraries.Application.Interfaces;
using DojoKitaoApp.Libraries.Domain.Entities;
using DojoKitaoApp.Libraries.Domain.Interfaces.Repositories;

namespace DojoKitaoApp.Libraries.Application.Services;

public class EnderecoServiceApi : IEnderecoServiceApi
{
    private readonly IMapper mapper;
    private readonly IEnderecoRepository repository;

    public EnderecoServiceApi(IEnderecoRepository repository)
    {
        this.repository = repository;
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<EnderecoProfile>();
        });
        mapper = configuration.CreateMapper();
    }

    public async Task<IEnumerable<ReadEnderecoDto>> ListarTodosOsEnderecos()
    {
        var enderecos = await repository.ListarTodosAsync();
        return mapper.Map<List<ReadEnderecoDto>>(enderecos);
    }

    public ReadEnderecoDto? RecuperarEnderecoPeloId(int id)
    {
        var endereco = repository.RecuperarPor(endereco => endereco.Id == id);
        return endereco != null ? mapper.Map<ReadEnderecoDto>(endereco) : null;
    }

    public async Task<int> CriarNovoEndereco(CreateEnderecoDto enderecoDto)
    {
        var endereco = mapper.Map<Endereco>(enderecoDto);
        return await repository.AdicionarEnderecoAsync(endereco);
    }

    public async Task<bool> AtualizarEndereco(int id, UpdateEnderecoDto enderecoDto)
    {
        var endereco = repository.RecuperarPor(x => x.Id == id);
        if (endereco == null) return false;
        mapper.Map(enderecoDto, endereco);
        await repository.AtualizarAsync(endereco);
        return true;
    }
}
