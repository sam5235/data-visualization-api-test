using data_visualization_api.Application.Common.Interfaces;
using data_visualization_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace data_visualization_api.Infrastructure.Data.Repositories;

public class IndicatorRepository : IIndicatorRepository
{
  private readonly ApplicationDbContext _context;

  public IndicatorRepository(ApplicationDbContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<Indicator>> GetIndicatorsByTopicIdAsync(int topicId)
  {
    return await _context.Indicators
        .AsNoTracking()
        .Where(i => i.TopicIds.Contains(topicId))
        .ToListAsync();
  }

  public async Task<IEnumerable<Indicator>> GetIndicatorsByRootIdAsync(int rootId)
  {
    return await _context.Indicators
        .AsNoTracking()
        .Where(i => i.RootIndicatorId == rootId)
        .ToListAsync();
  }
}
