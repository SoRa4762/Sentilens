using api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Core.Services.OTPServices
{
    public class OTPService : IOTPService
    {
        public string GenerateOTP()
        {
            var random = new Random();
            var otp = random.Next(100000, 999999).ToString();
            return otp;
        }

        public OTPValidationResult ValidateOTP(User user, string otp)
        {
            if (user.OtpExpiration < DateTime.UtcNow)
                return new OTPValidationResult(false, "The OTP has expired.");

            if (user.OtpAttemptCount >= 5)
                return new OTPValidationResult(false, "You have crossd the 5 attempt limits, try again later!");

            if(user.OtpSecret != otp)
            {
                user.OtpAttemptCount++;
                return new OTPValidationResult(false, "The OTP is incorrect.");
            }

            return new OTPValidationResult(true, "The OTP is valid.");
        }
    }
}
