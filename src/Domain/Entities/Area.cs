namespace data_visualization_api.Domain.Entities;
public class Area : BaseAuditableEntity
{
  public string AreaCode { get; set; } = string.Empty;
  public string NameEn { get; set; } = string.Empty;
  public string NameFr { get; set; } = string.Empty;
  public string? Iso3 { get; set; } = null;
}
