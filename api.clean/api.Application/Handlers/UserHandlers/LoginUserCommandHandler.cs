using api.Application.Commands.UserCommands;
using api.Application.Responses;
using api.Core.Entities;
using api.Core.Interfaces;
using api.Core.Services.AuthenticationServices;
using api.Core.Utilities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Handlers.UserHandlers
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result<UserResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public LoginUserCommandHandler(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<Result<UserResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null)
                return Result<UserResponse>.Failure("Invalid email or password");

            if (!await _userRepository.CheckPasswordAsync(user, request.Password))
                return Result<UserResponse>.Failure("Invalid email or password");

            var userResponse = new UserResponse(_tokenService.GenerateToken(user))
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName
            };

            return Result<UserResponse>.Success(userResponse);
        }
    }
}
