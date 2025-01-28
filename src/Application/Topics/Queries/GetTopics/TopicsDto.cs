using data_visualization_api.Domain.Entities;

namespace data_visualization_api.Application.Topics.Queries;

public class TopicDto
{
  public string TopicCode { get; init; } = string.Empty;
  public string TopicEn { get; init; } = string.Empty;
  public string TopicFr { get; init; } = string.Empty;
  public int Order { get; init; }
  public string DescriptionEn { get; init; } = string.Empty;
  public string DescriptionFr { get; init; } = string.Empty;
  public string MainTopicEn { get; init; } = string.Empty;
  public string MainTopicFr { get; init; } = string.Empty;
  public int[] RootIndicatorIds { get; init; } = Array.Empty<int>();

  private class Mapping : Profile
  {
    public Mapping()
    {
      CreateMap<Topic, TopicDto>();
    }
  }
}
