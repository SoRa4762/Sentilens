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
            var feedSourceList = await _mediator.Send(query);
            return Ok(feedSourceList);
        }

        [HttpGet("{feedSourceId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<FeedSourceResponse>> GetFeedSourceByIdAsync(int feedSourceId)
        {
            var query = new GetFeedSourceByIdQuery(feedSourceId);
            var feedSource = await _mediator.Send(query);
            return Ok(feedSource);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<FeedSourceResponse>> CreateFeedSourceAsync(CreateFeedSourceCommand command)
        {
            var feedSource = await _mediator.Send(command);
            return Ok(feedSource);

            /*  Realized it quite late but... maybe I don't have to return CreatedAtAction and only feedSource cuz this time the data will be handled by handler and presented through Response DTO 
                Console.WriteLine($"feedSource.Id: {feedSource.Id}");
                return CreatedAtAction(
                    actionName: nameof(GetFeedSourceByIdAsync),
                    controllerName: "v1/FeedSource",
                    routeValues: new { feedSourceId = feedSource.Id },
                    value: feedSource
                );
            */
        }

        /* 
         * Parameter of HTTP functions are case-sensitive
         * [HttpDelete("{FeedSourceId}")] and DeleteFeedSourceIdById(int feedSourceId) are not the same
         * you get the error `"{feedSourceId}" does not exist/invalid` (kinda) on Swagger
         */
        [HttpDelete("{feedSourceId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FeedSourceResponse>> DeleteFeedSourceById(int feedSourceId)
        {
            var query = new DeleteFeedSourceByIdQuery(feedSourceId);
            var feedSource = await _mediator.Send(query);
            if (feedSource == null) return NotFound("Feed Source Not Found!");
            return Ok(feedSource);
        }
    }
}
