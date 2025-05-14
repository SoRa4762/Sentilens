using api.Core.Utilities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Commands.UserTopicCommands
{ 
    public record AddUserTopicCommand(string UserId, int TopicId) : IRequest<Result<bool>>;
}
