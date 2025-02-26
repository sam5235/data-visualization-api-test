using MediatR;
using data_visualization_api.Application.Common.Interfaces;
using data_visualization_api.Application.Common.Models;
using Microsoft.Extensions.Logging;

namespace data_visualization_api.Application.Charts.Commands.DeleteChart;

public class DeleteChartCommand : IRequest<Result<int>>
{
  public int Id { get; set; }
}

public class DeleteChartCommandHandler : IRequestHandler<DeleteChartCommand, Result<int>>
{
  private readonly IChartRepository _repository;
  private readonly ILogger<DeleteChartCommandHandler> _logger;

  public DeleteChartCommandHandler(IChartRepository repository, ILogger<DeleteChartCommandHandler> logger)
  {
    _repository = repository;
    _logger = logger;
  }

  public async Task<Result<int>> Handle(DeleteChartCommand request, CancellationToken cancellationToken)
  {
    try
    {
      var chart = await _repository.GetChartByIdAsync(request.Id);
      if (chart == null)
      {
        return Result<int>.Failure("Chart not found.");
      }

      await _repository.DeleteChartAsync(chart);
      return Result<int>.Success(request.Id);
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "An error occurred while deleting the chart.");
      return Result<int>.Failure("An error occurred while deleting the chart.");
    }
  }
}
