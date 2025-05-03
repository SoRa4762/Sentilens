using api.Application.Responses;
using api.Core.Utilities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Commands.UserCommands
{
    public record LoginUserCommand(
        string Email,
        string Password,
        bool RememberMe
    ) : IRequest<Result<UserResponse>>;
}
