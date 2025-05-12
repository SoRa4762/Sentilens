using api.Application.Queries.UserQueries;
using api.Application.Responses;
using api.Core.Interfaces;
using api.Core.Utilities;
using MediatR;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Handlers.UserTopicHandlers
{
    public class GetUserTopicQueryHandler : IRequestHandler<GetUserTopicQuery, Result<UserTopicResponse>>
    {
        private readonly IUserTopicRepository _userTopicRepository;
        public GetUserTopicQueryHandler(IUserTopicRepository userTopicRepository)
        {
            _userTopicRepository = userTopicRepository;
        }

        public async Task<Result<UserTopicResponse>> Handle(GetUserTopicQuery request, CancellationToken cancellationToken)
        {
            var userTopic = await _userTopicRepository.GetUserTopicByIdAsync(request.UserId, request.TopicId);
            if(userTopic == null)
                return Result<UserTopicResponse>.Failure("User topic not found");

            var userTopicResponse = new UserTopicResponse
            {
                UserId = userTopic.UserId,
                TopicName = userTopic.Topic.Name,
                SubscribedDate = userTopic.SubscribedDate
            };

            return Result<UserTopicResponse>.Success(userTopicResponse);
        }
    }
}
