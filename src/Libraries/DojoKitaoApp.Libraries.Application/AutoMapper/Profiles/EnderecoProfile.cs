using AutoMapper;
using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Endereco;
using DojoKitaoApp.Libraries.Domain.Entities;

namespace DojoKitaoApp.Libraries.Application.AutoMapper.Profiles;

public class EnderecoProfile : Profile
{
    public EnderecoProfile()
    {
        CreateMap<CreateEnderecoDto, Endereco>();
        CreateMap<Endereco, ReadEnderecoDto>();
        CreateMap<UpdateEnderecoDto, Endereco>();
    }
}
