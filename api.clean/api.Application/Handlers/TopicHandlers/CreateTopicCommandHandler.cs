using api.Application.Commands.TopicCommands;
using api.Application.Mappers.TopicMapper;
using api.Application.Responses;
using api.Core.Entities;
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
    public class CreateTopicCommandHandler : IRequestHandler<CreateTopicCommand, Result<TopicResponse>>
    {
        private readonly ITopicRepository _topicRepository;
        public CreateTopicCommandHandler(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public async Task<Result<TopicResponse>> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
        {
            var mappedTopic = TopicMapper.Mapper.Map<Topic>(request);
            var createdTopic = await _topicRepository.AddAsync(mappedTopic);

            if (createdTopic == null)
                return Result<TopicResponse>.Failure("Failed to create topic");

            var mappedTopicResponse = TopicMapper.Mapper.Map<TopicResponse>(createdTopic);

            return Result<TopicResponse>.Success(mappedTopicResponse);
        }
    }
}
