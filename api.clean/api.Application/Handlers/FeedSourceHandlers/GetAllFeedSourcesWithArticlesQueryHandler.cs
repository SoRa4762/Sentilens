using api.Application.Mappers.FeedSourceMapper;
using api.Application.Queries.FeedSourceQueries;
using api.Application.Responses;
using api.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Handlers.FeedSourceHandlers
{
    public class GetAllFeedSourcesWithArticlesQueryHandler : IRequestHandler<GetAllFeedSourcesWithArticlesQuery, IReadOnlyList<FeedSourceResponse>>
    {
        private protected readonly IFeedSourceRepository _feedSourceRepo;
        public GetAllFeedSourcesWithArticlesQueryHandler(IFeedSourceRepository feedSourceRepo)
        {
            _feedSourceRepo = feedSourceRepo;
        }
        public async Task<IReadOnlyList<FeedSourceResponse>> Handle(GetAllFeedSourcesWithArticlesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var feedSourcesArticles = await _feedSourceRepo.GetAllFeedSourcesWithArticles();
                return FeedSourceMapper.Mapper.Map<IReadOnlyList<FeedSourceResponse>>(feedSourcesArticles);
            } catch (Exception ex){
                throw new Exception("Error while getting all feed sources with articles", ex);
            }
        }
    }
}
