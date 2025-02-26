using data_visualization_api.Domain.Entities;
using data_visualization_api.Application.Charts.Commands.CreateChart;
using data_visualization_api.Application.Charts.Queries.GetCharts;
using data_visualization_api.Application.Charts.Commands.UpdateChart;

namespace data_visualization_api.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Map CreateChartCommand to Chart
        CreateMap<CreateChartCommand, Chart>()
            .ForMember(dest => dest.SelectedCountriesData, opt => opt.MapFrom(src => src.SelectedCountriesData))
            .ForMember(dest => dest.LegendOptions, opt => opt.MapFrom(src => src.LegendOptions));

        // Map UpdateChartCommand to Chart
        // CreateMap<UpdateChartCommand, Chart>()
        //     .ForMember(dest => dest.Id, opt => opt.Ignore())
        //     .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<UpdateChartCommand, Chart>()
          .ForMember(dest => dest.Id, opt => opt.Ignore())
          .ForMember(dest => dest.SelectedCountriesData, opt => opt.MapFrom(src => src.SelectedCountriesData))
          .ForMember(dest => dest.LegendOptions, opt => opt.MapFrom(src => src.LegendOptions))
          .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
              srcMember != null &&
              !srcMember.GetType().IsValueType ||
              (srcMember != null && srcMember.GetType().IsValueType && !srcMember.Equals(GetDefaultValue(srcMember.GetType())))));

        // Map CountryDataDto to CountryData
        CreateMap<CountryDataDto, CountryData>();

        // Map LegendOptionDto to LegendOptions
        CreateMap<LegendOptionDto, LegendOptions>();

        // Map Chart to ChartDto (for queries)
        CreateMap<Chart, ChartDto>();
        CreateMap<CountryData, CountryDataDto>();
        CreateMap<LegendOptions, LegendOptionDto>();
    }
    private static object? GetDefaultValue(Type type)
        => type.IsValueType ? Activator.CreateInstance(type) : null;
}
