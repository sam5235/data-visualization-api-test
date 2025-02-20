
using data_visualization_api.Domain.Entities;
namespace data_visualization_api.Application.Charts.Queries.GetCharts;
public class TimeSeriesDataDto
{
  public int Year { get; set; }
  public double Value { get; set; }
}