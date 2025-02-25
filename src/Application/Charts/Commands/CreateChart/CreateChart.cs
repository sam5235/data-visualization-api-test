using MediatR;
using data_visualization_api.Domain.Entities;
using data_visualization_api.Application.Common.Interfaces;
using Microsoft.Extensions.Logging;

namespace data_visualization_api.Application.Charts.Commands.CreateChart;

public class CreateChartCommand : IRequest<int>
{
  public string SelectedChartType { get; set; } = string.Empty;
  public string SelectedIndicatorName { get; set; } = string.Empty;
  public string Thumbnail { get; set; } = string.Empty;
  public int? StartYear { get; set; }
  public int? EndYear { get; set; }
  public string XAxisLabel { get; set; } = string.Empty;
  public string YAxisLabel { get; set; } = string.Empty;
  public string ChartTitle { get; set; } = string.Empty;
  public List<CountryData> SelectedCountriesData { get; set; } = [];
  public List<Indicator> SelectedIndicators { get; set; } = [];
  public List<Topic> SelectedTopics { get; set; } = [];
  public LegendOptions LegendOptions { get; set; } = new();
}

public class CreateChartCommandHandler : IRequestHandler<CreateChartCommand, int>
{
  private readonly IChartRepository _repository;
  private readonly IMapper _mapper;
  private readonly ILogger _logger;

  public CreateChartCommandHandler(IChartRepository repository, IMapper mapper, ILogger<CreateChartCommandHandler> logger)
  {
    _repository = repository;
    _mapper = mapper;
    _logger = logger;
  }

  public async Task<int> Handle(CreateChartCommand request, CancellationToken cancellationToken)
  {

    _logger.LogInformation("Creating a new Chart");
    var chart = _mapper.Map<Chart>(request);
    _logger.LogInformation("Adding the new Chart to the repository");
    await _repository.AddChartAsync(chart);
    _logger.LogInformation("New Chart created with Id: {0}", chart.Id);
    return chart.Id;
  }
}