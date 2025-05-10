using api.Application.Commands.UserCommands;
using api.Core.Entities;
using api.Core.Interfaces;
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
    public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommand, Result<bool>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository _userRepository;

        public UpdatePasswordCommandHandler(
            UserManager<User> userManager,
            IUserRepository userRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public async Task<Result<bool>> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.email);
            if (user == null)
                return Result<bool>.Failure("User not found");

            // Check current password
            var isMatch = await _userRepository.CheckPasswordAsync(user, request.currentPassword);
            if (!isMatch)
                return Result<bool>.Failure("Current Password is incorrect");

            // Update password
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, request.newPassword);
            if(result.Succeeded)
            {
                return Result<bool>.Success(true);
            }
            else
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return Result<bool>.Failure($"Failed to update password: {errors}");
            }
        }
    }
}
