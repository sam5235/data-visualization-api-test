using data_visualization_api.Application.Common.Interfaces;

namespace data_visualization_api.Application.Areas.Queries.GetAreas;

public record GetAreasQuery : IRequest<AreasVm>
{
}

public class GetAreasQueryHandler : IRequestHandler<GetAreasQuery, AreasVm>
{
    private readonly IAreaRepository _areaRepository;
    private readonly IMapper _mapper;

    public GetAreasQueryHandler(IAreaRepository areaRepository, IMapper mapper)
    {
        _areaRepository = areaRepository;
        _mapper = mapper;
    }

    public async Task<AreasVm> Handle(GetAreasQuery request, CancellationToken cancellationToken)
    {
        var areas = await _areaRepository
            .GetAreasAsync(cancellationToken);
        var areaDtos = _mapper.Map<List<AreaDto>>(areas);
        return new AreasVm { Areas = areaDtos };
    }
}
