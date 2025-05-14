using api.Application.Responses;
using api.Core.Utilities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Queries.TopicQueries
{
    public class GetTopicByIdQuery : IRequest<Result<TopicResponse>>
    {
        public int topicId { get; set; }
        public GetTopicByIdQuery(int topicId)
        {
            this.topicId = topicId;
        }
    }
}
