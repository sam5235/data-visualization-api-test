using data_visualization_api.Domain.Entities;
namespace data_visualization_api.Application.Indicators.Queries;

public class IndicatorDto
{
  public int Id { get; init; }
  public string NameEn { get; init; } = string.Empty;
  public string DescriptionEn { get; init; } = string.Empty;
  public string UnitEn { get; init; } = string.Empty;

  private class Mapping : Profile
  {
    public Mapping()
    {
      CreateMap<Indicator, IndicatorDto>();
    }
  }
}