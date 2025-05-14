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
    public class DeleteTopicByIdQueryHandler : IRequestHandler<DeleteTopicByIdQuery, Result<TopicResponse>>
    {
        private readonly ITopicRepository _topicRepository;
        public DeleteTopicByIdQueryHandler(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public async Task<Result<TopicResponse>> Handle(DeleteTopicByIdQuery request, CancellationToken cancellationToken)
        {
            var existingTopic = await _topicRepository.GetByIdAsync(request.topicId);
            if(existingTopic == null)
                return Result<TopicResponse>.Failure("Topic Not Found!");

            var deletedTopic = await _topicRepository.Delete(existingTopic);
            var mappedTopic = TopicMapper.Mapper.Map<TopicResponse>(deletedTopic);

            return Result<TopicResponse>.Success(mappedTopic);
        }
    }
}
