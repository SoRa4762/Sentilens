using api.Application.Queries.UserTopicQueries;
using api.Application.Responses;
using api.Core.Interfaces;
using api.Core.Utilities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Handlers.UserTopicHandlers
{
    public class GetUserTopicsByUserIdQueryHandler : IRequestHandler<GetUserTopicsByUserIdQuery, Result<IReadOnlyList<UserTopicResponse>>>
    {
        private readonly IUserTopicRepository _userTopicRepository;
        public GetUserTopicsByUserIdQueryHandler(IUserTopicRepository userTopicRepository)
        {
            _userTopicRepository = userTopicRepository;
        }

        public async Task<Result<IReadOnlyList<UserTopicResponse>>> Handle(GetUserTopicsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var userTopics = await _userTopicRepository.GetUserTopicsByUserIdAsync(request.userId);
            if (userTopics == null)
                return Result<IReadOnlyList<UserTopicResponse>>.Failure("User not found!");

            var mappedUserTopics = userTopics.Select(ut => new UserTopicResponse
            {
                UserId = ut.UserId,
                TopicId = ut.TopicId,
                TopicName = ut.Topic.Name,
                SubscribedDate = ut.SubscribedDate
            });

            return Result<IReadOnlyList<UserTopicResponse>>.Success(mappedUserTopics.ToList());
        }
    }
}
