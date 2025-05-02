using api.Api.Controllers.Base;
using api.Application.Commands.UserCommands;
using api.Application.Handlers.UserHandlers;
using api.Application.Responses;
using api.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Api.Controllers
{
    public class UserController : ApiController
    {
        private readonly IMediator _mediator; // to send commands and queries

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserResponse>> RegisterUser(RegisterUserCommand command)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _mediator.Send(command);

            if (user == null)
            {
                return BadRequest("User already exists");
            }
            //return CreatedAtAction(nameof(RegisterUser), new { username = user.UserName }, user);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserResponse>> LoginUser(LoginUserCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _mediator.Send(command);

            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            return Ok(user);
        }
    }
}
