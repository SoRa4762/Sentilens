using api.Application.Commands.UserCommands;
using api.Core.Entities;
using api.Core.Services.OTPServices;
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
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, Result<bool>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IOTPService _otpService;

        public ResetPasswordCommandHandler(
            UserManager<User> userManager,
            IOTPService otpService)
        {
            _userManager = userManager;
            _otpService = otpService;
        }

        public async Task<Result<bool>> Handle(ResetPasswordCommand command, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(command.Email);
            if (user == null)
                return Result<bool>.Failure("User not found!");

            var validationResult = _otpService.ValidateOTP(user, command.Otp);
            if(!validationResult.isValid)
                return Result<bool>.Failure(validationResult.ErrorMessage);

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, command.NewPassword);

            if (!result.Succeeded)
                return Result<bool>.Failure(result.Errors.Select(e => e.Description).ToArray());

            // clear OTP after successful reset
            user.OtpSecret = null;
            user.OtpExpiration = null;
            await _userManager.UpdateAsync(user);

            return Result<bool>.Success(true);
        }
    }
}
