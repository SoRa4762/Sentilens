using api.Api.Controllers.Base;
using api.Application.Commands.FeedSourceCommands;
using api.Application.Queries.FeedSourceQueries;
using api.Application.Responses;
using api.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace api.Api.Controllers
{
    public class FeedSourceController: ApiController
    {
        private readonly IMediator _mediator;
        public FeedSourceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<FeedSourceResponse>> GetAllFeedSourceAsync()
        {
            var query = new GetAllFeedSourceQuery();
            var feedSource = await _mediator.Send(query);
            return Ok(feedSource);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<FeedSourceResponse>> CreateFeedSourceAsync(CreateFeedSourceCommand command)
        {
            var feedSource = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAllFeedSourceAsync), new { id = feedSource.Id }, feedSource);

        }
    }
}
