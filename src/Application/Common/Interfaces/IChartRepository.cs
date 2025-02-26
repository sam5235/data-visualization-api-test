using data_visualization_api.Domain.Entities;
namespace data_visualization_api.Application.Common.Interfaces;

public interface IChartRepository
{
  Task<Chart?> GetChartByIdAsync(int id);
  Task<IEnumerable<Chart>> GetAllChartsAsync();
  Task AddChartAsync(Chart chart);

  Task UpdateChartAsync(Chart chart);
  Task DeleteChartAsync(Chart chart);
}