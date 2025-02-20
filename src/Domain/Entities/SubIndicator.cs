namespace data_visualization_api.Domain.Entities;

public class SubIndicator : BaseAuditableEntity
{
  public int RootIndicatorId { get; set; }
  public int ReplId { get; set; }
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
  public double Multiplier { get; set; }
  public int RoundLevel { get; set; }
  public int[] TopicIds { get; set; } = Array.Empty<int>();
  public int CoverageCountry { get; set; }
  public int CoverageSubRegion { get; set; }
  public List<EdgeTimeSeriesData> EdgeTimeSeriesData { get; set; } = new();
  public List<TimeSeriesData> TimeSeriesData { get; set; } = new();
  public List<int> ThemeIndicatorIds { get; set; } = new();
  public List<int> SourcesIds { get; set; } = new();
  public int DataPoints { get; set; }
  public int EarliestYear { get; set; }
  public int LatestYear { get; set; }
  public int Coverage { get; set; }
}
