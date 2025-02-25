using data_visualization_api.Domain.Entities;
using data_visualization_api.Application.Charts.Commands.CreateChart;
using data_visualization_api.Application.Charts.Queries.GetCharts;
using System.Text.Json;

namespace data_visualization_api.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Map CreateChartCommand to Chart
        CreateMap<CreateChartCommand, Chart>()
            .ForMember(dest => dest.SelectedCountriesData, opt => opt.MapFrom(src => src.SelectedCountriesData))
            .ForMember(dest => dest.SelectedIndicators, opt => opt.MapFrom(src => src.SelectedIndicators))
            .ForMember(dest => dest.SelectedTopics, opt => opt.MapFrom(src => src.SelectedTopics))
            .ForMember(dest => dest.LegendOptions, opt => opt.MapFrom(src => src.LegendOptions));

        // Map CountryDataDto to CountryData
        CreateMap<CountryDataDto, CountryData>();

        // Map IndicatorDto to Indicator
        CreateMap<IndicatorDto, Indicator>();

        // Map TopicDto to Topic
        CreateMap<TopicDto, Topic>();

        // Map LegendOptionDto to LegendOptions
        CreateMap<LegendOptionDto, LegendOptions>();

        // Map Chart to ChartDto (for queries)
        CreateMap<Chart, ChartDto>();
        CreateMap<CountryData, CountryDataDto>();
        CreateMap<Indicator, IndicatorDto>();
        CreateMap<Topic, TopicDto>();
        CreateMap<LegendOptions, LegendOptionDto>();
    }

    private static string JsonSerialize<T>(T value)
    {
        return JsonSerializer.Serialize(value);
    }

    private static T JsonDeserialize<T>(string json)
    {
        try
        {
            return JsonSerializer.Deserialize<T>(json)!;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return default!;
        }
    }
}
