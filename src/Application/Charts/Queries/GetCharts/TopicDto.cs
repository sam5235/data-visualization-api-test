using data_visualization_api.Domain.Entities;
namespace data_visualization_api.Application.Charts.Queries.GetCharts;

public class TopicDto
{
  public int TopicId { get; set; }
  public string TopicCode { get; init; } = string.Empty;
  public string TopicEn { get; init; } = string.Empty;
  public string TopicFr { get; init; } = string.Empty;
  public int Order { get; init; }
  public string DescriptionEn { get; init; } = string.Empty;
  public string DescriptionFr { get; init; } = string.Empty;
  public string MainTopicEn { get; init; } = string.Empty;
  public string MainTopicFr { get; init; } = string.Empty;
  private class Mapping : Profile
  {
    public Mapping()
    {
      CreateMap<Topic, TopicDto>();
    }
  }
}