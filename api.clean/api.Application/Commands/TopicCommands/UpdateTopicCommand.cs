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
    public class UpdateTopicCommand() : IRequest<Result<TopicResponse>>
    {
        public int topicId { get; set; }
        public string name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
    }
}
