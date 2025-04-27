using api.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Queries.FeedSourceQueries
{
    public class DeleteFeedSourceByIdQuery : IRequest<FeedSourceResponse>
    {
        public int FeedSourceId { get; set; }
        public DeleteFeedSourceByIdQuery(int feedSourceId)
        {
            FeedSourceId = feedSourceId;
        }
    }
}
