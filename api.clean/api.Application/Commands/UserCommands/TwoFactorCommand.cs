using api.Application.Responses;
using api.Core.Entities;
using api.Core.Utilities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Commands.UserCommands
{
    public record TwoFactorCommand(
        string email,
        string otp
    ) : IRequest<Result<UserResponse>>;
}
