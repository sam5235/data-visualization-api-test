using data_visualization_api.Domain.Common;

namespace data_visualization_api.Domain.Entities;

public class Indicator : BaseAuditableEntity
{
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
  public double Multiplier { get; set; }
  public int RoundLevel { get; set; }
  public int[] TopicIds { get; set; } = Array.Empty<int>();
}
