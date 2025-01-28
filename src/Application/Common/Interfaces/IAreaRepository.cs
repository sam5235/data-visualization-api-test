using data_visualization_api.Domain.Entities;
namespace data_visualization_api.Application.Common.Interfaces

{
  public interface IAreaRepository
  {
    Task<IEnumerable<Area>> GetAreasAsync(CancellationToken cancellationToken);
  }
}