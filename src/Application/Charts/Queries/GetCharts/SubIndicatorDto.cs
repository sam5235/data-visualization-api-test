using data_visualization_api.Domain.Entities;
namespace data_visualization_api.Application.Charts.Queries.GetCharts;

public class SubIndicatorDto
{
  public int RootIndicatorId { get; init; }
  public int ReplId { get; init; }
  public string ShortNameEn { get; init; } = string.Empty;
  public string ShortNameFr { get; init; } = string.Empty;
  public string NameEn { get; init; } = string.Empty;
  public string NameFr { get; init; } = string.Empty;
  public string DescriptionEn { get; init; } = string.Empty;
  public string DescriptionFr { get; init; } = string.Empty;
  public string ModeEn { get; init; } = string.Empty;
  public string ModeFr { get; init; } = string.Empty;
  public string UnitEn { get; init; } = string.Empty;
  public string UnitFr { get; init; } = string.Empty;
  public string ScaleEn { get; init; } = string.Empty;
  public string ScaleFr { get; init; } = string.Empty;
  public string Multiplier { get; init; } = string.Empty;
  public int CoverageCountry { get; init; }
  public int CoverageSubRegion { get; init; }
  public int RoundLevel { get; init; }
  public List<EdgeTimeSeriesDataDto> EdgeTimeSeriesData { get; set; } = new();
  public List<TimeSeriesDataDto> TimeSeriesData { get; set; } = new();
  public List<int> TopicIds { get; init; } = new();
  public List<int> ThemeIndicatorIds { get; init; } = new();
  public List<int> SourcesIds { get; init; } = new();
  public int DataPoints { get; init; }
  public int EarliestYear { get; init; }
  public int LatestYear { get; init; }
  public int Coverage { get; init; }

  private class Mapping : Profile
  {
    public Mapping()
    {
      CreateMap<SubIndicator, SubIndicatorDto>();
    }
  }
}