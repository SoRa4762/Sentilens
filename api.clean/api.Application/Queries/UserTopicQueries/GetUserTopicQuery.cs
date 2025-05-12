using api.Application.Responses;
using api.Core.Utilities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Queries.UserQueries
{
    public class GetUserTopicQuery : IRequest<Result<UserTopicResponse>>
    {
        public string UserId { get; set; }
        public int TopicId { get; set; }
        public GetUserTopicQuery(string userId, int topicId)
        {
            UserId = userId;
            TopicId = topicId;
        }
    }
}
