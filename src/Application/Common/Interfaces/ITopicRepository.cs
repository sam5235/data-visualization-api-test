using data_visualization_api.Domain.Entities;

namespace data_visualization_api.Application.Common.Interfaces
{
  public interface ITopicRepository
  {
    Task<IEnumerable<Topic>> GetTopicsAsync(CancellationToken cancellationToken);
  }
}