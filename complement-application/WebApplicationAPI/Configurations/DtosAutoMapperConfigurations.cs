using AutoMapper;
using WebApplicationAPI.Models;
using WebApplicationEntities;

namespace WebApplicationAPI.Configurations;

public class DtosAutoMapperConfigurations : Profile
{
    public DtosAutoMapperConfigurations()
    {
        CreateMap<PcrTest, PcrTestDto>()
            .ReverseMap();
    }
}