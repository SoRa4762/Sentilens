using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Core.Services.OTPServices
{
    public record OTPValidationResult(bool isValid, string ErrorMessage = "");
}
