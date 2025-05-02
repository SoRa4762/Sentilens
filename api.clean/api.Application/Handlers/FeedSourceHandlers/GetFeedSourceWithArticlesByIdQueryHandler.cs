using api.Application.Mappers.FeedSourceMapper;
using api.Application.Queries.FeedSourceQueries;
using api.Application.Responses;
using api.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.ObjectPool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Handlers.FeedSourceHandlers
{
    public class GetFeedSourceWithArticlesByIdQueryHandler : IRequestHandler<GetFeedSourceWithArticlesByIdQuery, FeedSourceResponse>
    {
        private protected readonly IFeedSourceRepository _feedSourceRepo;
        public GetFeedSourceWithArticlesByIdQueryHandler(IFeedSourceRepository feedSourceRepo)
        {
            _feedSourceRepo = feedSourceRepo;
        }
        public async Task<FeedSourceResponse> Handle(GetFeedSourceWithArticlesByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var feedSourceArticles = await _feedSourceRepo.GetFeedSourceWithArticlesById(request.FeedSourceId);
                return FeedSourceMapper.Mapper.Map<FeedSourceResponse>(feedSourceArticles);
            } catch (Exception ex){
                throw new Exception("Error while getting all feed sources with articles", ex);
            }
        }
    }
}
