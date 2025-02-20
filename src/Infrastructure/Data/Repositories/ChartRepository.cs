using data_visualization_api.Application.Common.Interfaces;
using data_visualization_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace data_visualization_api.Infrastructure.Data.Repositories;

public class ChartRepository(ApplicationDbContext context) : IChartRepository
{
  private readonly ApplicationDbContext _context = context;

  public async Task<Chart?> GetChartByIdAsync(int id)
  {
    return await _context.Charts.FindAsync(id);
  }

  public async Task<List<Chart>> GetChartsAsync(CancellationToken cancellationToken)
  {
    return await _context.Charts.ToListAsync(cancellationToken);
  }

  public async Task AddChartAsync(Chart chart)
  {
    await _context.Charts.AddAsync(chart);
    await _context.SaveChangesAsync();
  }
}
