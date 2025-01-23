using data_visualization_api.Domain.Entities;

namespace data_visualization_api.Application.Common.Interfaces
{
  public interface ITopicRepository
  {
    Task<List<Topic>> GetTopicsAsync();
    Task<Topic> GetTopicByIdAsync(int id);
    Task<Topic> CreateTopicAsync(Topic topic);
    Task UpdateTopicAsync(Topic topic);
    Task DeleteTopicAsync(Topic topic);
  }
}