using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Responses
{
    public class UserResponse
    {
        public string UserName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Token { get; set; } = String.Empty;
    }
}
