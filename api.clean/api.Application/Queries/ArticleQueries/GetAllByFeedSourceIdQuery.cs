using api.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Queries.ArticleQueries
{
    public class GetAllByFeedSourceIdQuery : IRequest<IReadOnlyList<ArticleResponse>>
    {
        public int FeedSourceId { get; set; }
        public GetAllByFeedSourceIdQuery(int feedSourceId)
        {
            FeedSourceId = feedSourceId;
        }
    }
}
