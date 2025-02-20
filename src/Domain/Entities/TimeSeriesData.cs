namespace data_visualization_api.Domain.Entities;

public class TimeSeriesData
{
  public int Id { get; set; } // Primary key
  public int Year { get; set; } // Key (year)
  public double Value { get; set; } // Value (data point)

  // Foreign key to the parent entity (EdgeTimeSeriesData)
  public int EdgeTimeSeriesDataId { get; set; }
  public EdgeTimeSeriesData EdgeTimeSeriesData { get; set; } = null!;
}