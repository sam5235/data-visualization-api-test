using System.Text.Json;
using data_visualization_api.Application.Common.Interfaces;
using Microsoft.Extensions.Logging;
namespace data_visualization_api.Application.Charts.Queries.GetCharts;

public class GetChartsQuery : IRequest<ChartsVm> { }

public class GetChartsQueryHandler : IRequestHandler<GetChartsQuery, ChartsVm>
{
  private readonly IChartRepository _chartRepository;
  private readonly IMapper _mapper;

  private readonly ILogger<GetChartsQueryHandler> _logger;

  public GetChartsQueryHandler(IChartRepository chartRepository, IMapper mapper, ILogger<GetChartsQueryHandler> logger)
  {
    _chartRepository = chartRepository;
    _mapper = mapper;
    _logger = logger;

  }

  public async Task<ChartsVm> Handle(GetChartsQuery request, CancellationToken cancellationToken)
  {
    try
    {
      _logger.LogInformation("Getting Charts from the repository");
      var charts = await _chartRepository.GetAllChartsAsync();

      _logger.LogInformation("Mapping Charts to ChartDto");
      var chartDto = _mapper.Map<List<ChartDto>>(charts);

      return new ChartsVm { Charts = chartDto };
    }
    catch (JsonException ex)
    {
      _logger.LogError(ex, "Failed to deserialize JSON data. Please check the YearDataJson column in the database.");
      throw new ApplicationException("An error occurred while processing the chart data. Please check the data format.", ex);
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "An unexpected error occurred while retrieving charts.");
      throw new ApplicationException("An unexpected error occurred. Please try again later.", ex);
    }
  }
}