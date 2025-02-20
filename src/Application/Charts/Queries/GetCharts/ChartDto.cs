using data_visualization_api.Domain.Entities;
namespace data_visualization_api.Application.Charts.Queries.GetCharts;
public class ChartDto
{
  public int Id { get; init; }
  public string SelectedChartType { get; init; } = string.Empty;
  public string SelectedIndicatorName { get; init; } = string.Empty;
  public string Thumbnail { get; init; } = string.Empty;
  public string LegendOptions { get; init; } = string.Empty;
  public int? StartYear { get; init; }
  public int? EndYear { get; init; }
  public string XAxisLabel { get; init; } = string.Empty;
  public string YAxisLabel { get; init; } = string.Empty;
  public string ChartTitle { get; init; } = string.Empty;
  public List<SubIndicatorDto> SelectedIndicators { get; init; } = new();
  public List<TopicDto> SelectedTopics { get; init; } = new();

  private class Mapping : Profile
  {
    public Mapping()
    {
      CreateMap<Chart, ChartDto>();
      CreateMap<ChartDto, Chart>();
    }
  }
}