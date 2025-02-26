using MediatR;
using data_visualization_api.Application.Common.Interfaces;
using data_visualization_api.Application.Common.Models;
using Microsoft.Extensions.Logging;
using AutoMapper;
using data_visualization_api.Domain.Entities;

namespace data_visualization_api.Application.Charts.Commands.UpdateChart;

public class UpdateChartCommand : IRequest<Result<int>>
{
  public int Id { get; set; }
  public string SelectedChartType { get; set; } = string.Empty;
  public string SelectedIndicatorName { get; set; } = string.Empty;
  public string Thumbnail { get; set; } = string.Empty;
  public int? StartYear { get; set; }
  public int? EndYear { get; set; }
  public string XAxisLabel { get; set; } = string.Empty;
  public string YAxisLabel { get; set; } = string.Empty;
  public string ChartTitle { get; set; } = string.Empty;

  public bool Share { get; set; } = false;
  public bool Published { get; set; } = false;
  public List<int> SelectedIndicators { get; set; } = [];
  public List<int> SelectedTopics { get; set; } = [];
  public List<CountryData> SelectedCountriesData { get; set; } = [];
  public LegendOptions LegendOptions { get; set; } = new();
}

public class UpdateChartCommandHandler : IRequestHandler<UpdateChartCommand, Result<int>>
{
  private readonly IChartRepository _repository;
  private readonly IMapper _mapper;
  private readonly ILogger _logger;

  public UpdateChartCommandHandler(IChartRepository repository, IMapper mapper, ILogger<UpdateChartCommandHandler> logger)
  {
    _repository = repository;
    _mapper = mapper;
    _logger = logger;
  }

  public async Task<Result<int>> Handle(UpdateChartCommand request, CancellationToken cancellationToken)
  {
    // try
    // {
    //   if (request.Id <= 0)
    //   {
    //     return Result<int>.Failure("Invalid chart id.");
    //   }
    //   var chart = await _repository.GetChartByIdAsync(request.Id);

    //   if (chart == null)
    //   {
    //     return Result<int>.Failure("Chart not found.");
    //   }

    //   chart = _mapper.Map(request, chart);

    //   await _repository.UpdateChartAsync(chart);

    //   return Result<int>.Success(chart.Id);
    // }
    try
    {
      if (request.Id <= 0)
        return Result<int>.Failure("Invalid chart id.");

      var chart = await _repository.GetChartByIdAsync(request.Id);
      if (chart == null)
        return Result<int>.Failure("Chart not found.");

      // Explicit mapping for owned entities
      _mapper.Map(request.LegendOptions, chart.LegendOptions);

      // Merge country data updates
      foreach (var country in request.SelectedCountriesData)
      {
        var existing = chart.SelectedCountriesData
            .FirstOrDefault(c => c.CountryId == country.CountryId);

        if (existing != null)
          _mapper.Map(country, existing);
        else
          chart.SelectedCountriesData.Add(country);
      }

      // Map remaining properties
      _mapper.Map(request, chart);

      await _repository.UpdateChartAsync(chart);
      return Result<int>.Success(chart.Id);
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "An error occurred while updating the chart.");
      return Result<int>.Failure("An error occurred while updating the chart.");
    }
  }
}