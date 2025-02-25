namespace data_visualization_api.Application.Charts.Queries.GetCharts;
public class ChartDto
{
  public int Id { get; init; }
  public string SelectedChartType { get; init; } = string.Empty;
  public string SelectedIndicatorName { get; init; } = string.Empty;
  public string Thumbnail { get; init; } = string.Empty;
  public int? StartYear { get; init; }
  public int? EndYear { get; init; }
  public string XAxisLabel { get; init; } = string.Empty;
  public string YAxisLabel { get; init; } = string.Empty;
  public string ChartTitle { get; init; } = string.Empty;
  public ICollection<CountryDataDto> SelectedCountriesData { get; init; } = [];
  public ICollection<IndicatorDto> SelectedIndicators { get; init; } = [];
  public ICollection<TopicDto> SelectedTopics { get; init; } = [];

  public LegendOptionDto LegendOptions { get; init; } = new();
}

public class CountryDataDto
{
  public int CountryId { get; init; }
  public string CountryName { get; init; } = string.Empty;
  public Dictionary<string, int> YearData { get; init; } = [];
}

public class TopicDto
{
  public int SubIndicatorsCount { get; init; }
  public int DataPointsCount { get; init; }
  public int EarliestYear { get; init; }
  public int LatestYear { get; init; }
  public int CoverageCountryCount { get; init; }
  public int CoverageSubRegionCount { get; init; }
  public int TopicId { get; init; }
  public string TopicCode { get; init; } = string.Empty;
  public string TopicEn { get; init; } = string.Empty;
  public string TopicFr { get; init; } = string.Empty;
  public string DescriptionEn { get; init; } = string.Empty;
  public string DescriptionFr { get; init; } = string.Empty;
  public int Order { get; init; }
  public string MainTopicEn { get; init; } = string.Empty;
  public string MainTopicFr { get; init; } = string.Empty;
}

public class IndicatorDto
{
  public int ReplId { get; init; }
  public int RootIndicatorId { get; init; }
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
  public int Multiplier { get; init; }
  public int CoverageCountry { get; init; }

  public int CoverageSubRegion { get; init; }
  public int RoundLevel { get; init; }

  public List<int> EdgeTimeSeriesData { get; init; } = [];
  public List<int> TimeSeriesData { get; init; } = [];
  public List<int> TopicIds { get; init; } = [];
  public List<int> ThemeIndicatorIds { get; init; } = [];
  public List<int> SourcesIds { get; init; } = [];
  public int DataPoints { get; init; }
  public int EarliestYear { get; init; }
  public int LatestYear { get; init; }
  public int Coverage { get; init; }
}

public class LegendOptionDto
{

  public bool Show { get; init; }
  public string Orient { get; init; } = string.Empty;
  public string Align { get; init; } = string.Empty;
  public string Left { get; init; } = string.Empty;
  public string Top { get; init; } = string.Empty;
}