using api.Application.Commands.FeedSourceCommands;
using api.Application.Mappers.FeedSourceMapper;
using api.Application.Responses;
using api.Core.Entities;
using api.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Handlers.FeedSourceHandlers
{
    // since `CreateFeedSourceCommand` contains IRequest<FeedSourceResponse> you will not be able to map IRequest Handler with <CreateFeedSourceCommand, IReadonlyList<FeedSourceResponse>>
    public class CreateFeedSourceCommandHandler : IRequestHandler<CreateFeedSourceCommand, FeedSourceResponse>
    {
        private readonly IFeedSourceRepository _repository;
        public CreateFeedSourceCommandHandler(IFeedSourceRepository repository)
        {
            _repository = repository;
        }

        public async Task<FeedSourceResponse> Handle(CreateFeedSourceCommand request, CancellationToken cancellationToken)
        {
            // turn Create DTO to Entity
            var feedSourceEntity = FeedSourceMapper.Mapper.Map<FeedSource>(request);
            if (feedSourceEntity == null) {
                throw new ApplicationException("FeedSource Mapping Failed!");
            }

            var newFeedSource = await _repository.AddAsync(feedSourceEntity);
            // turn Entity to Response DTO
            var feedSourceResponse = FeedSourceMapper.Mapper.Map<FeedSourceResponse>(newFeedSource);
            return feedSourceResponse;
        }
    }
}
