using AutoMapper;
using WebApplication1.Models;
using WebApplicationEntities;

namespace WebApplication1.Configurations;

public class EditViewModelsAutoMapperConfigurations : Profile
{
    public EditViewModelsAutoMapperConfigurations()
    {
        // CreateMap<PcrTest, PcrTestEditViewModel>();
        // CreateMap<PcrTestEditViewModel, PcrTest>();
        // TODO: check about validation of configuration at startup
        CreateMap<PcrTest, PcrTestEditViewModel>()
            .ReverseMap();
        // CreateMap<PcrTest, PcrTestEditViewModel>(MemberList.Destination)
        //     .ForMember(x => x.SliPerformers, y => y.Ignore())
        //     .ReverseMap()
        //     .ForMember(x => x.CreationDate, y => y.Ignore());
    }
}