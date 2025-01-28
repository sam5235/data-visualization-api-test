namespace data_visualization_api.Application.Topics.Queries.GetTopics;
public class TopicsVm
{
  public IReadOnlyCollection<TopicDto> Topics { get; init; } = Array.Empty<TopicDto>();
}