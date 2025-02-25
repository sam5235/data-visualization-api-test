namespace data_visualization_api.Domain.Entities;
public class TimeSeriesData
{
  public int CountryId { get; set; }
  public string CountryNameEn { get; set; } = string.Empty;
  public string CountryNameFr { get; set; } = string.Empty;
  public string CountryCode { get; set; } = string.Empty;
  public int AreaType { get; set; }
  public int RootIndicatorId { get; set; }
  public int PeriodYear { get; set; }
  public decimal PeriodValue { get; set; }
}