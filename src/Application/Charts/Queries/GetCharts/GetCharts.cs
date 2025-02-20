using data_visualization_api.Application.Common.Interfaces;
namespace data_visualization_api.Application.Charts.Queries.GetCharts;

public class GetChartsQuery : IRequest<ChartsVm> { }

public class GetChartsQueryHandler : IRequestHandler<GetChartsQuery, ChartsVm>
{
  private readonly IChartRepository _chartRepository;
  private readonly IMapper _mapper;

  public GetChartsQueryHandler(IChartRepository chartRepository, IMapper mapper)
  {
    _chartRepository = chartRepository;
    _mapper = mapper;
  }

  public async Task<ChartsVm> Handle(GetChartsQuery request, CancellationToken cancellationToken)
  {
    var charts = await _chartRepository.GetChartsAsync(cancellationToken);
    var chartDto = _mapper.Map<List<ChartDto>>(charts);
    return new ChartsVm { Charts = chartDto };
  }
}