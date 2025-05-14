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
    public class GetTopicByIdQueryHandler : IRequestHandler<GetTopicByIdQuery, Result<TopicResponse>>
    {
        private readonly ITopicRepository _topicRepository;
        public GetTopicByIdQueryHandler(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public async Task<Result<TopicResponse>> Handle(GetTopicByIdQuery request, CancellationToken cancellationToken)
        {
            var topic = await _topicRepository.GetByIdAsync(request.topicId);
            if (topic == null)
                return Result<TopicResponse>.Failure("Topic Not Found!");

            var mappedTopic = TopicMapper.Mapper.Map<TopicResponse>(topic);
            return Result<TopicResponse>.Success(mappedTopic);
        }
    }
}
