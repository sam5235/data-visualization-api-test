namespace data_visualization_api.Application.Indicators.Queries;

public record GetIndicatorsByTopicIdQuery(int TopicId) : IRequest<List<IndicatorDto>>;

public class IndicatorDto
{
  public int Id { get; set; }
  public string NameEn { get; set; } = string.Empty;
  public string DescriptionEn { get; set; } = string.Empty;
  public string UnitEn { get; set; } = string.Empty;
}
