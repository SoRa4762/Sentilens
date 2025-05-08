using api.Core.Utilities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Commands.UserCommands
{
    // Result<bool> is a custom result type, not a standard C# type
    public record ForgotPasswordCommand(string Email) : IRequest<Result<bool>>; 
}
