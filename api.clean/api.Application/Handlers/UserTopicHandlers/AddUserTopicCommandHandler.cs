using api.Application.Commands.UserTopicCommands;
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
    public class AddUserTopicCommandHandler : IRequestHandler<AddUserTopicCommand, Result<bool>>
    {
        private readonly IUserTopicRepository _userTopicRepository;
        public AddUserTopicCommandHandler(IUserTopicRepository userTopicRepository)
        {
            _userTopicRepository = userTopicRepository;
        }

        public async Task<Result<bool>> Handle(AddUserTopicCommand request, CancellationToken cancellationToken)
        {
            var result = await _userTopicRepository.AddUserTopicAsync(request.UserId, request.TopicId);
            if (!result.IsSuccess)
                return Result<bool>.Failure(result.Errors);

            return Result<bool>.Success(true);
        }
    }
}
