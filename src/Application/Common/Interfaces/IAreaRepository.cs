using data_visualization_api.Domain.Entities;
namespace data_visualization_api.Application.Common.Interfaces

{
  public interface IAreaRepository
  {
    Task<List<Area>> GetAreasAsync();
    Task<Area> GetAreaByIdAsync(int id);
    Task<Area> CreateAreaAsync(Area area);
    Task UpdateAreaAsync(Area area);
    Task DeleteAreaAsync(Area area);
  }
}