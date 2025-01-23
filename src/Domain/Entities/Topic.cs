namespace data_visualization_api.Domain.Entities;

public class Topic
{
  public int TopicId { get; set; }
  public string TopicCode { get; set; } = string.Empty;
  public string TopicEn { get; set; } = string.Empty;
  public string TopicFr { get; set; } = string.Empty;
  public string DescriptionEn { get; set; } = string.Empty;
  public string DescriptionFr { get; set; } = string.Empty;
  public int[] RootIndicatorIds { get; set; } = Array.Empty<int>();
}
