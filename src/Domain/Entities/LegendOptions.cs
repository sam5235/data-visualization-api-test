namespace data_visualization_api.Domain.Entities;

public class LegendOptions
{
  public bool Show { get; set; }
  public string Orient { get; set; } = string.Empty;
  public string Align { get; set; } = string.Empty;
  public string Left { get; set; } = string.Empty;
  public string Top { get; set; } = string.Empty;
}