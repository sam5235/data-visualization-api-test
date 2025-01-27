namespace data_visualization_api.Application.Indicators.Queries;

public class IndicatorsVm
{
  public IReadOnlyCollection<IndicatorDto> Indicators { get; init; } = Array.Empty<IndicatorDto>();
}