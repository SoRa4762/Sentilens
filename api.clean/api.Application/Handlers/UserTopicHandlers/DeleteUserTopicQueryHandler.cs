using api.Application.Queries.UserTopicQueries;
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
    public class DeleteUserTopicQueryHandler : IRequestHandler<DeleteUserTopicQuery, Result<bool>>
    {
        private readonly IUserTopicRepository _userTopicRepository;
        public DeleteUserTopicQueryHandler(IUserTopicRepository userTopicRepository)
        {
            _userTopicRepository = userTopicRepository;
        }

        public async Task<Result<bool>> Handle(DeleteUserTopicQuery request, CancellationToken cancellationToken)
        {
            var result = await _userTopicRepository.DeleteUserTopic(request.userId, request.topicId);
            if (!result.IsSuccess)
                return Result<bool>.Failure(result.Errors);

            return Result<bool>.Success(true);
        }
    }
}
