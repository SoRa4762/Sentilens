using api.Application.Responses;
using api.Core.Utilities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Commands.UserCommands
{
    public record RegisterUserCommand(
        string Username, string Email, string Password
    ) : IRequest<Result<bool>>;
}
