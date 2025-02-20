namespace data_visualization_api.Domain.Entities;

public class Chart : BaseAuditableEntity
{
  public string SelectedChartType { get; set; } = string.Empty;
  public string SelectedIndicatorName { get; set; } = string.Empty;
  public string Thumbnail { get; set; } = string.Empty;
  public string LegendOptions { get; set; } = string.Empty;
  public int? StartYear { get; set; }
  public int? EndYear { get; set; }
  public string XAxisLabel { get; set; } = string.Empty;
  public string YAxisLabel { get; set; } = string.Empty;
  public string ChartTitle { get; set; } = string.Empty;
  public ICollection<SubIndicator> SelectedIndicators { get; set; } = new List<SubIndicator>();
  public ICollection<Topic> SelectedTopics { get; set; } = new List<Topic>();

}