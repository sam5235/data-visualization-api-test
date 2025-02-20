using data_visualization_api.Application.Common.Interfaces;
using data_visualization_api.Application.Charts.Queries.GetCharts;
using data_visualization_api.Domain.Entities;

namespace data_visualization_api.Application.Charts.Commands.CreateChart;


public record CreateChartCommand : IRequest<int>
{
  public required ChartDto Chart { get; init; }
}

public class CreateChartCommandHandler : IRequestHandler<CreateChartCommand, int>
{
  private readonly IChartRepository _chartRepository;
  private readonly IMapper _mapper;

  public CreateChartCommandHandler(IChartRepository chartRepository, IMapper mapper)
  {
    _chartRepository = chartRepository;
    _mapper = mapper;
  }

  public async Task<int> Handle(CreateChartCommand request, CancellationToken cancellationToken)
  {
    var chart = _mapper.Map<Chart>(request.Chart);

    await _chartRepository.AddChartAsync(chart);
    return chart.Id;
  }
}