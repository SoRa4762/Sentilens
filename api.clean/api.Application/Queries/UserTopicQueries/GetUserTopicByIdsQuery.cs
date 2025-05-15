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
    public record GetUserTopicByIdsQuery : IRequest<Result<IEnumerable<UserTopicResponse>>>
    {
        public string UserId { get; set; } = string.Empty;
        public int TopicId { get; set; }
        public GetUserTopicByIdsQuery(string userId, int topicId)
        {
            UserId = userId;
            TopicId = topicId;
        }
    }
}
