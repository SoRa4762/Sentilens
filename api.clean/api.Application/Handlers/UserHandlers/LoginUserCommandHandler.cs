using api.Application.Commands.UserCommands;
using api.Application.Responses;
using api.Core.Entities;
using api.Core.Interfaces;
using api.Core.Services.AuthenticationServices;
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
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result<UserResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;
        private readonly IOTPService _otpService;

        public LoginUserCommandHandler(IUserRepository userRepository, ITokenService tokenService, IEmailService emailService, IOTPService otpService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _emailService = emailService;
            _otpService = otpService;
        }

        public async Task<Result<UserResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null)
                return Result<UserResponse>.Failure("Invalid email or password");

            if (!await _userRepository.CheckPasswordAsync(user, request.Password))
                return Result<UserResponse>.Failure("Invalid email or password");

            if (user.TwoFactorEnabled)
            {
                // Handle two-factor authentication here
                var otp = _otpService.GenerateOTP();
                user.OtpAttemptCount = 0;
                user.OtpExpiration = DateTime.UtcNow.AddMinutes(10);
                user.OtpSecret = otp;

                await _userRepository.UpdateUserAsync(user);

                await _emailService.SendOTPEmail(user.Email, otp);
                return Result<UserResponse>.Failure("Your OTP has been sent to your Email. Please verify your identity.");
            } else
            {
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
}
