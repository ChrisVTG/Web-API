using System.Text.RegularExpressions;
using AutoMapper;
using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Configurations;

public class ListViewModelsAutoMapperConfigurations : Profile
{
    public ListViewModelsAutoMapperConfigurations()
    {
        CreateMap<PcrTest, PcrTestListItemViewModel>()
            .ForMember(x => x.Performer,
                y => y.MapFrom(z => z.Performer == null
                    ? ""
                    : $"{z.Performer.FirstName} {z.Performer.LastName}"))
            .ForMember(x => x.SampleNumber,
                y => y.MapFrom(z =>
                    $"{z.SampleNumber.Substring(0, 2)}{Regex.Replace(z.SampleNumber.Substring(2), ".", "*")}"));
    }
}