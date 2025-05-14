using api.Application.Mappers.TopicMapper;
using api.Application.Queries.TopicQueries;
using api.Application.Responses;
using api.Core.Interfaces;
using api.Core.Utilities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Handlers.TopicHandlers
{
    public class GetAllTopicQueryHandler : IRequestHandler<GetAllTopicQuery, Result<IReadOnlyList<TopicResponse>>>
    {
        private readonly ITopicRepository _topicRepository;
        public GetAllTopicQueryHandler(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public async Task<Result<IReadOnlyList<TopicResponse>>> Handle(GetAllTopicQuery request, CancellationToken cancellationToken)
        {
            var topics = await _topicRepository.GetAllAsync();
            if (topics == null || !topics.Any())
                return Result<IReadOnlyList<TopicResponse>>.Failure("No Topics found");

            var mappedTopics = TopicMapper.Mapper.Map<IReadOnlyList<TopicResponse>>(topics);
            return Result<IReadOnlyList<TopicResponse>>.Success(mappedTopics);
        }
    }
}
