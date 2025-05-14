using api.Api.Controllers.Base;
using api.Application.Commands.UserTopicCommands;
using api.Application.Queries.UserTopicQueries;
using api.Core.Utilities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace api.Api.Controllers
{
    public class UserTopicController : ApiController
    {
        private readonly IMediator _mediator;
        public UserTopicController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userId}/{topicId}")]
        public async Task<IActionResult> GetUserTopicById(string userId, int topicId)
        {
            var query = new GetUserTopicByIdQuery(userId, topicId);
            var result = await _mediator.Send(query);
            return result.Match<IActionResult>(
                success => Ok(success),
                failure => BadRequest(new { Errors = failure })
            );
        }

        [HttpPost]
        public async Task<IActionResult> AddUserTopic(AddUserTopicCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Match<IActionResult>(
                success => Ok(success),
                failure => BadRequest(new { Errors = failure })
            );
        }

        [HttpDelete("{userId}/{topicId}")]
        public async Task<IActionResult> DeleteUserTopic(string userId, int topicId)
        {
            var query = new DeleteUserTopicQuery(userId, topicId);
            var result = await _mediator.Send(query);
            return result.Match<IActionResult>(
                success => Ok(success),
                failure => BadRequest(new { Errors = failure })
            );
        }
    }
}
