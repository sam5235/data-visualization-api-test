namespace data_visualization_api.Domain.Entities;
public class Indicator
{
  public int ReplId { get; set; }
  public int RootIndicatorId { get; set; }
  public string ShortNameEn { get; set; } = string.Empty;
  public string ShortNameFr { get; set; } = string.Empty;
  public string NameEn { get; set; } = string.Empty;
  public string NameFr { get; set; } = string.Empty;
  public string DescriptionEn { get; set; } = string.Empty;
  public string DescriptionFr { get; set; } = string.Empty;
  public string ModeEn { get; set; } = string.Empty;
  public string ModeFr { get; set; } = string.Empty;
  public string UnitEn { get; set; } = string.Empty;
  public string UnitFr { get; set; } = string.Empty;
  public string ScaleEn { get; set; } = string.Empty;
  public string ScaleFr { get; set; } = string.Empty;
  public int Multiplier { get; set; }
  public int CoverageCountry { get; set; }
  public int CoverageSubRegion { get; set; }
  public int RoundLevel { get; set; }
  public List<int> EdgeTimeSeriesData { get; } = [];
  public List<int> TimeSeriesData { get; } = [];
  public List<int> TopicIds { get; set; } = [];
  public List<int> ThemeIndicatorIds { get; } = [];
  public List<int> SourcesIds { get; } = [];
  public int DataPoints { get; set; }
  public int EarliestYear { get; set; }
  public int LatestYear { get; set; }
  public int Coverage { get; set; }
}