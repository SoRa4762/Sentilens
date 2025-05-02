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
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, UserResponse>
    {
        private readonly SignInManager<User> _signInManager; // to check password
        private readonly ITokenService _tokenService; // to generate token
        private readonly UserManager<User> _userManager; // to get user by email

        public LoginUserCommandHandler(SignInManager<User> signInManager, ITokenService tokenService, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
            _userManager = userManager;
        }

        public async Task<UserResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

                if (result.Succeeded)
                {
                    var userResponse = UserMapper.Mapper.Map<UserResponse>(user);
                    var token = _tokenService.CreateToken(user);
                    userResponse.Token = token;
                    return userResponse;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while logging in", ex);
            }
        }
    }
}
