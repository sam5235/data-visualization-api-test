using data_visualization_api.Application.Charts.Queries.GetCharts;
using data_visualization_api.Application.Common.Interfaces;

namespace data_visualization_api.Application.Charts.Queries.GetChartById;

public record GetChartByIdQuery(int Id) : IRequest<ChartDto>;

public class GetChartByIdQueryHandler : IRequestHandler<GetChartByIdQuery, ChartDto>
{
  private readonly IChartRepository _repository;
  private readonly IMapper _mapper;

  public GetChartByIdQueryHandler(IChartRepository repository, IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  public async Task<ChartDto> Handle(GetChartByIdQuery request, CancellationToken cancellationToken)
  {
    var chart = await _repository.GetChartByIdAsync(request.Id);
    return _mapper.Map<ChartDto>(chart);
  }
}