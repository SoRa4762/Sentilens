using api.Application.Commands.UserCommands;
using api.Core.Entities;
using api.Core.Services.EmailServices;
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
    public class ForgetPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, Result<bool>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IOTPService _otpService;
        private readonly IEmailService _emailService;

        public ForgetPasswordCommandHandler(
            UserManager<User> userManager,
            IOTPService otpService,
            IEmailService emailService)
        {
            _userManager = userManager;
            _otpService = otpService;
            _emailService = emailService;
        }

        public async Task<Result<bool>> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                return Result<bool>.Failure("User not found");

            // Generate OTP
            var otp = _otpService.GenerateOTP();
            user.OtpSecret = otp;
            user.OtpExpiration = DateTime.UtcNow.AddMinutes(10);
            user.OtpAttemptCount = 0;

            await _userManager.UpdateAsync(user);
            await _emailService.SendOTPEmail(user.Email, otp);
            return Result<bool>.Success(true);
        }
    }
}
