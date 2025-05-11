using api.Application.Commands.UserCommands;
using api.Application.Responses;
using api.Core.Entities;
using api.Core.Interfaces;
using api.Core.Services.AuthenticationServices;
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
    public class TwoFactorCommandHandler : IRequestHandler<TwoFactorCommand, Result<UserResponse>>
    {
        private readonly IOTPService _otpService;
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;
        public TwoFactorCommandHandler(IOTPService otpService, ITokenService tokenService, IUserRepository userRepository) {
            _otpService = otpService;
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        public async Task<Result<UserResponse>> Handle(TwoFactorCommand request, CancellationToken cancellationToken)
        {
            if(string.IsNullOrEmpty(request.otp))
                return Result<UserResponse>.Failure("OTP cannot be empty");

            var user = await _userRepository.GetByEmailAsync(request.email);
            if(user == null)
                return Result<UserResponse>.Failure("User not found");

            var result = _otpService.ValidateOTP(user, request.otp);

            if (!result.isValid)
                return Result<UserResponse>.Failure(result.ErrorMessage);

            var token = _tokenService.GenerateToken(user);

            var userResponse = new UserResponse(token)
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName
            };

            // Optionally, you can also clear the OTP after successful validation
            user.OtpAttemptCount = 0;
            user.OtpSecret = null;
            user.OtpExpiration = null;
            
            // save changes
            await _userRepository.UpdateUserAsync(user);

            return Result<UserResponse>.Success(userResponse);
        }
    }
}
