using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace data_visualization_api.Domain.Entities;
public class CountryData
{
  public int CountryId { get; set; }
  public string CountryName { get; set; } = string.Empty;

  [JsonIgnore]
  public string YearDataJson { get; set; } = string.Empty;

  [NotMapped]
  public Dictionary<string, int> YearData
  {
    get => JsonSerializer.Deserialize<Dictionary<string, int>>(YearDataJson) ?? new Dictionary<string, int>();
    set => YearDataJson = JsonSerializer.Serialize(value);
  }

}
