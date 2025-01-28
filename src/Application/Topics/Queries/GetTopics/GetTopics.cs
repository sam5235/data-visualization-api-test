using data_visualization_api.Application.Common.Interfaces;

namespace data_visualization_api.Application.Topics.Queries.GetTopics;

public record GetTopicsQuery : IRequest<TopicsVm>
{
}

public class GetTopicsQueryHandler : IRequestHandler<GetTopicsQuery, TopicsVm>
{
    private readonly ITopicRepository _topicRepository;
    private readonly IMapper _mapper;

    public GetTopicsQueryHandler(ITopicRepository topicRepository, IMapper mapper)
    {
        _topicRepository = topicRepository;
        _mapper = mapper;
    }

    public async Task<TopicsVm> Handle(GetTopicsQuery request, CancellationToken cancellationToken)
    {
        var topics = await _topicRepository
            .GetTopicsAsync(cancellationToken);
        var topicDtos = _mapper.Map<List<TopicDto>>(topics);
        return new TopicsVm { Topics = topicDtos };
    }
}
