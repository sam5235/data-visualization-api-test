namespace data_visualization_api.Domain.Entities;
public class CountryData
{
  public int CountryId { get; set; }
  public string CountryName { get; set; } = string.Empty;

  public Dictionary<string, decimal> YearData { get; set; } = new();
}
