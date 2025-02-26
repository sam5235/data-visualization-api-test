using MediatR;
using data_visualization_api.Domain.Entities;
using data_visualization_api.Application.Common.Interfaces;
using Microsoft.Extensions.Logging;
using data_visualization_api.Application.Common.Models;

namespace data_visualization_api.Application.Charts.Commands.CreateChart;

public class CreateChartCommand : IRequest<Result<int>>
{
  public string SelectedChartType { get; set; } = string.Empty;
  public string SelectedIndicatorName { get; set; } = string.Empty;
  public string Thumbnail { get; set; } = string.Empty;
  public int? StartYear { get; set; }
  public int? EndYear { get; set; }
  public string XAxisLabel { get; set; } = string.Empty;
  public string YAxisLabel { get; set; } = string.Empty;
  public string ChartTitle { get; set; } = string.Empty;
  public List<int> SelectedIndicators { get; set; } = [];
  public List<int> SelectedTopics { get; set; } = [];

  public List<CountryData> SelectedCountriesData { get; set; } = [];
  public LegendOptions LegendOptions { get; set; } = new();
}

public class CreateChartCommandHandler : IRequestHandler<CreateChartCommand, Result<int>>
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

  public async Task<Result<int>> Handle(CreateChartCommand request, CancellationToken cancellationToken)
  {

    try
    {
      var chart = _mapper.Map<Chart>(request);
      await _repository.AddChartAsync(chart);
      return Result<int>.Success(chart.Id);
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "An error occurred while creating the chart.");
      return Result<int>.Failure("An error occurred while creating the chart.");
    }
  }
}