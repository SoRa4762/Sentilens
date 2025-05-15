using api.Application.Queries.UserTopicQueries;
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

namespace api.Application.Handlers.UserTopicHandlers
{
    public class GetUserTopicByIdsQueryHandler : IRequestHandler<GetUserTopicByIdsQuery, Result<IEnumerable<UserTopicResponse>>>
    {
        private readonly IUserTopicRepository _userTopicRepository;
        public GetUserTopicByIdsQueryHandler(IUserTopicRepository userTopicRepository)
        {
            _userTopicRepository = userTopicRepository;
        }

        public async Task<Result<IEnumerable<UserTopicResponse>>> Handle(GetUserTopicByIdsQuery request, CancellationToken cancellationToken)
        {
            var userTopics = await _userTopicRepository.GetUserTopicByIdsAsync(request.UserId, request.TopicId);
            if (userTopics == null)
                return Result<IEnumerable<UserTopicResponse>>.Failure("User not found!");

            var mappedUserTopics = userTopics.Select(ut => new UserTopicResponse
            {
                UserId = ut.UserId,
                TopicId = ut.TopicId,
                TopicName = ut.Topic.Name,
                SubscribedDate = ut.SubscribedDate
            });

            return Result<IEnumerable<UserTopicResponse>>.Success(mappedUserTopics);
        }
    }
}
