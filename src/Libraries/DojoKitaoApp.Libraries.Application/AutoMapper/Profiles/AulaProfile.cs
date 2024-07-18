using AutoMapper;
using DojoKitaoApp.Libraries.Domain.Entities;
using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Aula;

namespace DojoKitaoApp.Libraries.Application.AutoMapper.Profiles;

public class AulaProfile : Profile
{
    public AulaProfile()
    {
        CreateMap<CreateAulaDto, Aula>();
        CreateMap<Aula, ReadAulaDto>();
    }
}
