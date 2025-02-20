namespace data_visualization_api.Application.Charts.Queries.GetCharts;

public class ChartsVm
{
  public IReadOnlyCollection<ChartDto> Charts { get; init; } = new List<ChartDto>();

}