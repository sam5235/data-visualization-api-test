using data_visualization_api.Domain.Entities;
namespace data_visualization_api.Application.Common.Interfaces;

public interface IChartRepository
{
  Task<Chart?> GetChartByIdAsync(int chartId);
  Task<List<Chart>> GetChartsAsync(CancellationToken cancellationToken);
  Task AddChartAsync(Chart chart);
}