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
    public class GetAllFeedSourcesQueryHandler : IRequestHandler<GetAllFeedSourcesQuery, IReadOnlyList<FeedSourceResponse>>
    {
        private readonly IFeedSourceRepository _feedSourceRepo;
        public GetAllFeedSourcesQueryHandler(IFeedSourceRepository feedSourceRepo)
        {
            _feedSourceRepo = feedSourceRepo;
        }

        public async Task<IReadOnlyList<FeedSourceResponse>> Handle(GetAllFeedSourcesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var feedSourceList = await _feedSourceRepo.GetAllAsync();
                // remember to map this list back to feedSourceResponse DTO
                var mappedList = FeedSourceMapper.Mapper.Map<IReadOnlyList<FeedSourceResponse>>(feedSourceList);
                return mappedList;
            } catch (Exception ex)
            {
                throw new Exception("Error while getting all feed sources", ex);
            }
        }
    }
}
