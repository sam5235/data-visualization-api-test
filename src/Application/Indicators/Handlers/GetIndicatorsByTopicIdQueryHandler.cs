using data_visualization_api.Application.Common.Interfaces;
using data_visualization_api.Application.Indicators.Queries;

namespace data_visualization_api.Application.Indicators.Handlers;

public class GetIndicatorsByTopicIdQueryHandler(IIndicatorRepository indicatorRepository) : IRequestHandler<GetIndicatorsByTopicIdQuery, List<IndicatorDto>>
{
  private readonly IIndicatorRepository _indicatorRepository = indicatorRepository;

  public async Task<List<IndicatorDto>> Handle(GetIndicatorsByTopicIdQuery request, CancellationToken cancellationToken)
  {
    var indicators = await _indicatorRepository.GetIndicatorsByTopicIdAsync(request.TopicId);

    return [.. indicators.Select(i => new IndicatorDto
        {
            Id = i.Id,
            NameEn = i.NameEn,
            DescriptionEn = i.DescriptionEn,
            UnitEn = i.UnitEn
        })];
  }
}
