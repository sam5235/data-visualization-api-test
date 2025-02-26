namespace data_visualization_api.Domain.Entities;

public class Topic
{
  public int TopicId { get; set; }
  public int SubIndicatorsCount { get; set; }
  public int DataPointsCount { get; set; }
  public int EarliestYear { get; set; }
  public int LatestYear { get; set; }
  public int CoverageCountryCount { get; set; }
  public int CoverageSubRegionCount { get; set; }
  public string TopicCode { get; set; } = string.Empty;
  public string TopicEn { get; set; } = string.Empty;
  public string TopicFr { get; set; } = string.Empty;
  public string DescriptionEn { get; set; } = string.Empty;
  public string DescriptionFr { get; set; } = string.Empty;
  public int Order { get; set; }
  public string MainTopicEn { get; set; } = string.Empty;
  public string MainTopicFr { get; set; } = string.Empty;
}
