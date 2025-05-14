using api.Api.Controllers.Base;
using api.Application.Commands.TopicCommands;
using api.Application.Queries.TopicQueries;
using api.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace api.Api.Controllers
{
    public class TopicController : ApiController
    {
        private readonly IMediator _mediator;
        public TopicController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTopic(CreateTopicCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Match<IActionResult>(
                success => Ok(success),
                failure => BadRequest(new { Errors = failure })
            );
        }

        [HttpGet("{topicId}")]
        public async Task<IActionResult> GetIdAsync(int topicId)
        {
            var query = new GetTopicByIdQuery(topicId);
            var result = await _mediator.Send(query);
            return result.Match<IActionResult>(
                success => Ok(success),
                failure => BadRequest(new { Errors = failure })
            );
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllTopic()
        {
            var query = new GetAllTopicQuery();
            var result = await _mediator.Send(query);
            return result.Match<IActionResult>(
                success => Ok(success),
                failure => BadRequest(new { Errors = failure })
            );
        }

        [HttpPut("{topicId}")]
        public async Task<IActionResult> UpdateTopic(int topicId, [FromBody] UpdateTopicCommand command)
        {
            command.topicId = topicId;
            var updatedTopic = await _mediator.Send(command);
            return updatedTopic.Match<IActionResult>(
                success => Ok(success),
                failure => BadRequest(new { Errors = failure })
            );
        }

        [HttpDelete("{topicId}")]
        public async Task<IActionResult> DeleteTopic(int topicId)
        {
            var query = new DeleteTopicByIdQuery(topicId);
            var deletedTopic = await _mediator.Send(query);
            return deletedTopic.Match<IActionResult>(
                success => Ok(success),
                failure => BadRequest(new { Errors = failure })
            );
        }
    }
}
