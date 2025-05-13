using api.Application.Responses;
using api.Core.Utilities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Queries.UserTopicQueries
{
    public record GetUserTopicByIdQuery : IRequest<Result<IEnumerable<UserTopicResponse>>>
    {
        public string UserId { get; set; } = string.Empty;
        public int TopicId { get; set; }
        public GetUserTopicByIdQuery(string userId, int topicId)
        {
            UserId = userId;
            TopicId = topicId;
        }
    }
}
