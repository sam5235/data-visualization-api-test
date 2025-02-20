namespace data_visualization_api.Domain.Entities;

public class EdgeTimeSeriesData
{
  public int Id { get; set; } // Primary key
  public string CountryId { get; set; } = string.Empty; // Unique identifier for the country
  public string CountryName { get; set; } = string.Empty; // Name of the country

  // Navigation property for time series data
  public List<TimeSeriesData> YearData { get; set; } = new();

  // Foreign key to the parent entity (SubIndicator)
  public int SubIndicatorId { get; set; }
  public SubIndicator SubIndicator { get; set; } = null!;
}