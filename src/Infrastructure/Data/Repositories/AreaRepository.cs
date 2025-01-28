using data_visualization_api.Application.Common.Interfaces;
using data_visualization_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace data_visualization_api.Infrastructure.Data.Repositories;

public class AreaRepository(ApplicationDbContext context) : IAreaRepository
{
  private readonly ApplicationDbContext _context = context;

  public async Task<IEnumerable<Area>> GetAreasAsync(CancellationToken cancellationToken)
  {
    try
    {
      var areas = await _context.Areas
      .AsNoTracking()
      .OrderBy(t => t.NameEn)
      .ToListAsync(cancellationToken);

      return areas.Count == 0 ? throw new InvalidOperationException("Areas not found") : areas;
    }
    catch (Exception e)
    {
      Console.WriteLine(e); throw;
    }
  }
}