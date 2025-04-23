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
    public class GetAllFeedSourceHandler : IRequestHandler<GetAllFeedSourceQuery, IReadOnlyList<FeedSourceResponse>>
    {
        private readonly IFeedSourceRepository _feedSourceRepo;
        public GetAllFeedSourceHandler(IFeedSourceRepository feedSourceRepo)
        {
            _feedSourceRepo = feedSourceRepo;
        }

        public async Task<IReadOnlyList<FeedSourceResponse>> Handle(GetAllFeedSourceQuery request, CancellationToken cancellationToken)
        {
            var feedSourceList = await _feedSourceRepo.GetAllAsync();
            // remember to map this list back to feedSourceResponse DTO
            var mappedList = FeedSourceMapper.Mapper.Map<IReadOnlyList<FeedSourceResponse>>(feedSourceList);
            return mappedList;
        }
    }
}
