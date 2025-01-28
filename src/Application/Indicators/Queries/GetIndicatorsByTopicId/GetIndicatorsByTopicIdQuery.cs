namespace data_visualization_api.Application.Indicators.Queries;

public record GetIndicatorsByTopicIdQuery : IRequest<IndicatorsVm>
{
  public int TopicId { get; }

  public GetIndicatorsByTopicIdQuery(int topicId)
  {
    TopicId = topicId;
  }
}