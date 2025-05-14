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
    public class UpdateTopicCommandHandler : IRequestHandler<UpdateTopicCommand, Result<TopicResponse>>
    {
        private readonly ITopicRepository _topicRepository;
        public UpdateTopicCommandHandler(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public async Task<Result<TopicResponse>> Handle(UpdateTopicCommand request, CancellationToken cancellationToken)
        {
            var existingTopic = await _topicRepository.GetByIdAsync(request.topicId);
            if (existingTopic == null)
                return Result<TopicResponse>.Failure("Topic Not Found!");

            TopicMapper.Mapper.Map(request, existingTopic);
            var updatedTopic = await _topicRepository.UpdateAsync(existingTopic);

            return Result<TopicResponse>.Success(TopicMapper.Mapper.Map<TopicResponse>(updatedTopic));
        }
    }
}
