using Microsoft.AspNetCore.Mvc;
using DojoKitaoApp.Libraries.Application.Interfaces;
using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Endereco;

namespace DojoKitaoApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EnderecosController(IEnderecoServiceApi service) : ControllerBase
{
    private readonly IEnderecoServiceApi service = service;

    [HttpGet]
    public async Task<IEnumerable<ReadEnderecoDto>> ListarEnderecos()
    {
        return await service.ListarTodosOsEnderecos();
    }

    [HttpGet("{id}")]
    public IActionResult RecuperarEnderecoPeloId(int id)
    {
        var enderecoDto = service.RecuperarEnderecoPeloId(id);
        return enderecoDto != null ? Ok(enderecoDto) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CriarNovoEndereco([FromBody] CreateEnderecoDto enderecoDto)
    {
        int idEndereco = await service.CriarNovoEndereco(enderecoDto);
        return idEndereco > 0 ? Ok(idEndereco) : NotFound();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
    {
        return await service.AtualizarEndereco(id, enderecoDto) ? NoContent() : NotFound();
    }
}
