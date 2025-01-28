using data_visualization_api.Domain.Entities;

namespace data_visualization_api.Application.Areas.Queries.GetAreas;

public class AreaDto
{
  public string AreaCode { get; init; } = string.Empty;
  public string NameEn { get; init; } = string.Empty;
  public string NameFr { get; init; } = string.Empty;
  public string? Iso3 { get; init; } = null;

  private class Mapping : Profile
  {
    public Mapping()
    {
      CreateMap<Area, AreaDto>();
    }
  }
}