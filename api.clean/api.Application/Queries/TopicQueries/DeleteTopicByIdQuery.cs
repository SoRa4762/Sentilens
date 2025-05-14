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
    public class DeleteTopicByIdQuery : IRequest<Result<TopicResponse>>
    {
        public int topicId { get; set; }
        public DeleteTopicByIdQuery(int topicId)
        {
            this.topicId = topicId;
        }
    }
}
