using api.Api.Controllers.Base;
using api.Application.Commands.UserCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace api.Api.Controllers
{
    public class UserController : ApiController
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Match<IActionResult>(
                success => Ok(success),
                failure => BadRequest(new { Errors = failure })
                );
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Match<IActionResult>(
                success => Ok(success),
                failure => BadRequest(new { Errors = failure })
                );
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Match<IActionResult>(
                success => Ok(success),
                failure => BadRequest(new { Errors = failure })
                );
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Match<IActionResult>(
                success => Ok(success),
                failure => BadRequest(new { Errors = failure })
                );
        }
    }
}
