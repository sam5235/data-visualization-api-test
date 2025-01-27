using data_visualization_api.Application.Common.Interfaces;
using data_visualization_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace data_visualization_api.Infrastructure.Data.Repositories;

public class IndicatorRepository(ApplicationDbContext context) : IIndicatorRepository
{
  private readonly ApplicationDbContext _context = context;

  public async Task<IEnumerable<Indicator>> GetIndicatorsByTopicIdAsync(int topicId)
  {
    try
    {
      var indicators = await Task.Run(() => _context.Indicators.AsEnumerable()
           .Where(indicator => indicator.TopicIds.Any(t => t == topicId)).ToList());

      return indicators.Count == 0 ? throw new InvalidOperationException("Indicators not found") : (IEnumerable<Indicator>)indicators;
    }
    catch (Exception e)
    {
      Console.WriteLine(e); throw;
    }
  }
}
