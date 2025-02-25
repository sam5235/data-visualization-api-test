
namespace data_visualization_api.Domain.Entities;
public class EdgeTimeSeriesData
{
  public int CountryId { get; set; }
  public string CountryCode { get; set; } = string.Empty;
  public string CountryEn { get; set; } = string.Empty;
  public string CountryFr { get; set; } = string.Empty;
  public int AreaType { get; set; }
  public int RootIndicatorId { get; set; }
  public int EarliestYear { get; set; }
  public decimal EarliestYearValue { get; set; }
  public int LatestYear { get; set; }
  public decimal LatestYearValue { get; set; }
}