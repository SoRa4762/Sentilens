using api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Core.Services.OTPServices
{
    public interface IOTPService
    {
        string GenerateOTP();
        OTPValidationResult ValidateOTP(User user, string otp);
    }
}
