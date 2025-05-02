using api.Application.Commands.UserCommands;
using api.Application.Mappers.UserMapper;
using api.Application.Responses;
using api.Core.Entities;
using api.Core.Services.AuthenticationServices;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Handlers.UserHandlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserResponse>
    {
        private readonly UserManager<User> _userManager; // to create users, to add roles, to find users
        private readonly ITokenService _tokenService; // to create tokens if user is authenticated or created

        public RegisterUserCommandHandler(UserManager<User> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<UserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = UserMapper.Mapper.Map<User>(request);
                var registerUser = await _userManager.CreateAsync(user, request.Password);

                if (registerUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, "User");
                    if (roleResult.Succeeded)
                    {
                        var token = _tokenService.CreateToken(user);
                        var mappedUser = UserMapper.Mapper.Map<UserResponse>(user);
                        mappedUser.Token = token;
                        return mappedUser;
                    }
                    else
                    {
                        throw new Exception("Error adding role to user");
                    }
                }
                else
                {
                    throw new Exception("Error creating user");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error mapping user", ex);
            }
        }
    }
}
