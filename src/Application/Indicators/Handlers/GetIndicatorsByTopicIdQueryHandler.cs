using data_visualization_api.Application.Common.Interfaces;
using data_visualization_api.Application.Indicators.Queries;

namespace data_visualization_api.Application.Indicators.Handlers;

public class GetIndicatorsByTopicIdQueryHandler : IRequestHandler<GetIndicatorsByTopicIdQuery, IndicatorsVm>
{
  private readonly IIndicatorRepository _indicatorRepository;
  private readonly IMapper _mapper;

  public GetIndicatorsByTopicIdQueryHandler(IIndicatorRepository indicatorRepository, IMapper mapper)
  {
    _indicatorRepository = indicatorRepository;
    _mapper = mapper;
  }

  public async Task<IndicatorsVm> Handle(GetIndicatorsByTopicIdQuery request, CancellationToken cancellationToken)
  {
    var indicators = await _indicatorRepository.GetIndicatorsByTopicIdAsync(request.TopicId);

    var indicatorDtos = _mapper.Map<List<IndicatorDto>>(indicators);
    return new IndicatorsVm { Indicators = indicatorDtos };
  }
}
