using api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Core.Services.AuthenticationServices
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
