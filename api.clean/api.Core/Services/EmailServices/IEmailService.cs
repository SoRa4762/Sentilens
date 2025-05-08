using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Core.Services.EmailServices
{
    public interface IEmailService
    {
        Task SendOTPEmail(string email, string otp);
    }
}
