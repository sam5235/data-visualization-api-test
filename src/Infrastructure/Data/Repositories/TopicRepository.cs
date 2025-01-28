using data_visualization_api.Application.Common.Interfaces;
using data_visualization_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace data_visualization_api.Infrastructure.Data.Repositories;

public class TopicRepository(ApplicationDbContext context) : ITopicRepository
{
  private readonly ApplicationDbContext _context = context;

  public async Task<IEnumerable<Topic>> GetTopicsAsync(CancellationToken cancellationToken)
  {
    try
    {
      var topics = await _context.Topics
      .AsNoTracking()
      .OrderBy(t => t.Order)
      .ToListAsync(cancellationToken);

      return topics.Count == 0 ? throw new InvalidOperationException("Topics not found") : topics;
    }
    catch (Exception e)
    {
      Console.WriteLine(e); throw;
    }
  }
}