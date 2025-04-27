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
    public class GetFeedSourceByIdQueryHandler : IRequestHandler<GetFeedSourceByIdQuery, FeedSourceResponse>
    {
        private readonly IFeedSourceRepository _feedSourceRepo;
        public GetFeedSourceByIdQueryHandler(IFeedSourceRepository feedSourceRepo)
        {
            _feedSourceRepo = feedSourceRepo;
        }

        public async Task<FeedSourceResponse> Handle(GetFeedSourceByIdQuery request, CancellationToken cancellationToken)
        {
            var feedSource = await _feedSourceRepo.GetByIdAsync(request.FeedSourceId);
            var mappedFeedSource = FeedSourceMapper.Mapper.Map<FeedSourceResponse>(feedSource);
            return mappedFeedSource;
        }
    }
}
