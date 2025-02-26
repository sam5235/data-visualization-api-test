using data_visualization_api.Domain.Entities;
using data_visualization_api.Application.Charts.Commands.CreateChart;
using data_visualization_api.Application.Charts.Queries.GetCharts;

namespace data_visualization_api.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Map CreateChartCommand to Chart
        CreateMap<CreateChartCommand, Chart>()
            .ForMember(dest => dest.SelectedCountriesData, opt => opt.MapFrom(src => src.SelectedCountriesData))
            .ForMember(dest => dest.LegendOptions, opt => opt.MapFrom(src => src.LegendOptions));

        // Map CountryDataDto to CountryData
        CreateMap<CountryDataDto, CountryData>();

        // Map LegendOptionDto to LegendOptions
        CreateMap<LegendOptionDto, LegendOptions>();

        // Map Chart to ChartDto (for queries)
        CreateMap<Chart, ChartDto>();
        CreateMap<CountryData, CountryDataDto>();
        CreateMap<LegendOptions, LegendOptionDto>();
    }
}
