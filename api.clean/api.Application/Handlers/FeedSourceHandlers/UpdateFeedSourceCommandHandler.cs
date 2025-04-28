using api.Application.Commands.FeedSourceCommands;
using api.Application.Mappers.FeedSourceMapper;
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
    public class UpdateFeedSourceCommandHandler : IRequestHandler<UpdateFeedSourceCommand, FeedSourceResponse>
    {
        private protected readonly IFeedSourceRepository _feedSourceRepository;

        public UpdateFeedSourceCommandHandler(IFeedSourceRepository feedSourceRepository)
        {
            _feedSourceRepository = feedSourceRepository;
        }

        public async Task<FeedSourceResponse> Handle(UpdateFeedSourceCommand command, CancellationToken cancellationToken)
        {
            var existingFeedSource = await _feedSourceRepository.GetByIdAsync(command.FeedSourceId);
            if(existingFeedSource == null)
            {
                throw new KeyNotFoundException($"Feed source with ID {command.FeedSourceId} not found.");
            }
            // map and turn command DTO to entity - must do
            FeedSourceMapper.Mapper.Map(command, existingFeedSource);
            var updatedFeedSource = await _feedSourceRepository.UpdateAsync(existingFeedSource);
            // turn Entity to Response DTO
            return FeedSourceMapper.Mapper.Map<FeedSourceResponse>(updatedFeedSource);
        }
    }
}
