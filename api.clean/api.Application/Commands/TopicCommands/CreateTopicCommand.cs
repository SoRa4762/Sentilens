using api.Application.Responses;
using api.Core.Utilities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Commands.TopicCommands
{
    public record CreateTopicCommand(string name, string description) : IRequest<Result<TopicResponse>>;
}
