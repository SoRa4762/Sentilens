using api.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Commands.UserCommands
{
    public class LoginUserCommand : IRequest<UserResponse>
    {
        //[Required]
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public bool RememberMe { get; set; } = false;
    }
}
