using data_visualization_api.Domain.Entities;
using data_visualization_api.Infrastructure.Data;
using data_visualization_api.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using data_visualization_api.Application.Charts.Queries.GetCharts;

namespace data_visualization_api.Infrastructure.Repositories;

public class ChartRepository : IChartRepository
{
  private readonly ApplicationDbContext _context;
  private readonly ILogger _logger;
  private readonly IMapper _mapper;
  public ChartRepository(ApplicationDbContext context, ILogger<ChartRepository> logger, IMapper mapper)
  {
    _context = context;
    _logger = logger;
    _mapper = mapper;
  }

  public async Task<Chart?> GetChartByIdAsync(int id)
  {
    return await _context.Charts
      .Include(c => c.SelectedCountriesData)
      .FirstOrDefaultAsync(c => c.Id == id);
  }

  public async Task<IEnumerable<Chart>> GetAllChartsAsync()
  {
    try
    {
      _logger.LogInformation("Retrieving all charts from the database.");
      return await _context.Charts
        .AsNoTracking()
        .Include(c => c.SelectedCountriesData)
        .ToListAsync();
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "An error occurred while retrieving charts from the database.");
      throw;
    }
  }

  public async Task AddChartAsync(Chart chart)
  {
    _logger.LogInformation("Adding a new Chart to the repository");
    await _context.Charts.AddAsync(chart);
    _logger.LogInformation("Saving changes to the database");
    await _context.SaveChangesAsync();
  }
}