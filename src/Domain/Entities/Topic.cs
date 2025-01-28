namespace data_visualization_api.Domain.Entities;

public class Topic : BaseAuditableEntity
{
  public string TopicCode { get; set; } = string.Empty;
  public string TopicEn { get; set; } = string.Empty;
  public string TopicFr { get; set; } = string.Empty;
  public int Order { get; set; }
  public string DescriptionEn { get; set; } = string.Empty;
  public string DescriptionFr { get; set; } = string.Empty;
  public string MainTopicEn { get; set; } = string.Empty;
  public string MainTopicFr { get; set; } = string.Empty;
  public int[] RootIndicatorIds { get; set; } = Array.Empty<int>();
}
