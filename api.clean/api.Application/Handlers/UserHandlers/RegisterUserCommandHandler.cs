using api.Application.Commands.UserCommands;
using api.Application.Responses;
using api.Core.Entities;
using api.Core.Interfaces;
using api.Core.Services.AuthenticationServices;
using api.Core.Utilities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Handlers.UserHandlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Result<bool>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService; // to create tokens if user is authenticated or created

        public RegisterUserCommandHandler(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<Result<bool>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByEmailAsync(request.Email);
            if (existingUser != null)
                return Result<bool>.Failure("User already exists");

            var user = new User { Email = request.Email, UserName = request.Username };
            var result = await _userRepository.CreateUserAsync(user, request.Password);
            
            if (!result.Succeeded)
            {
                var errorString = string.Join("\n", result.Errors.Select(e => e.Description));
                return Result<bool>.Failure(errorString);
            }

            //var userResponse = new UserResponse(_tokenService.GenerateToken(user)){
            //    Id = user.Id,
            //    Email = user.Email,
            //    UserName = user.UserName
            //};

            return Result<bool>.Success(true);
        }
    }
}
