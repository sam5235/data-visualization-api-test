using data_visualization_api.Application.Charts.Queries.GetCharts;
using data_visualization_api.Application.Common.Interfaces;
namespace data_visualization_api.Application.Charts.Queries.GetChartById;

public record GetChartByIdQuery : IRequest<ChartsVm>
{
  public int ChartId { get; }

  public GetChartByIdQuery(int chartId)
  {
    ChartId = chartId;
  }
}

public class GetChartByIdQueryHandler : IRequestHandler<GetChartByIdQuery, ChartsVm>
{
  private readonly IChartRepository _chartRepository;
  private readonly IMapper _mapper;

  public GetChartByIdQueryHandler(IChartRepository chartRepository, IMapper mapper)
  {
    _chartRepository = chartRepository;
    _mapper = mapper;
  }

  public async Task<ChartsVm> Handle(GetChartByIdQuery request, CancellationToken cancellationToken)
  {
    var charts = await _chartRepository.GetChartByIdAsync(request.ChartId);

    var chartDto = _mapper.Map<List<ChartDto>>(charts);
    return new ChartsVm { Charts = chartDto };
  }
}
