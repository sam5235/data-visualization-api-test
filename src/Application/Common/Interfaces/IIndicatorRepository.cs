using data_visualization_api.Domain.Entities;

namespace data_visualization_api.Application.Common.Interfaces;

public interface IIndicatorRepository
{
  Task<IEnumerable<Indicator>> GetIndicatorsByTopicIdAsync(int topicId);
}
