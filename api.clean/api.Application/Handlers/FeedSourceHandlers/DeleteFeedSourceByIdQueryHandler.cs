using api.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api.Application.Queries.FeedSourceQueries;
using api.Core.Interfaces;
using api.Application.Mappers.FeedSourceMapper;

namespace api.Application.Handlers.FeedSourceHandlers
{
    public class DeleteFeedSourceByIdQueryHandler : IRequestHandler<DeleteFeedSourceByIdQuery, FeedSourceResponse>
    {
        public IFeedSourceRepository _feedSourceRepository { get; set; }
        public DeleteFeedSourceByIdQueryHandler(IFeedSourceRepository feedSourceRepository) {
            _feedSourceRepository = feedSourceRepository;
        }

        public async Task<FeedSourceResponse> Handle(DeleteFeedSourceByIdQuery request, CancellationToken cancellationToken)
        {
            var feedSource = await _feedSourceRepository.GetByIdAsync(request.FeedSourceId);
            if (feedSource == null) return null;
            await _feedSourceRepository.Delete(feedSource);
            // turn Entity to Response DTO
            var mappedFeedSource = FeedSourceMapper.Mapper.Map<FeedSourceResponse>(feedSource);
            return mappedFeedSource;
        }
    }
}
