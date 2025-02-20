using data_visualization_api.Domain.Entities;
namespace data_visualization_api.Application.Charts.Queries.GetCharts;
public class EdgeTimeSeriesDataDto
{
  public string CountryId { get; set; } = string.Empty;
  public string CountryName { get; set; } = string.Empty;
  public List<TimeSeriesDataDto> YearData { get; set; } = new();
}