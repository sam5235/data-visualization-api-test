namespace data_visualization_api.Domain.Entities;

public class TimePeriod
{
  public int TimePeriodId { get; set; }
  public int? Year { get; set; }
  public string? PeriodName { get; set; } = string.Empty;
}
