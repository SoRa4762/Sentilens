using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace api.Core.Entities
{
        // if it ain't public, it won't be serialized, won't be accessible to AppDbContext
    public class User : IdentityUser
    {
        // for 2FA or Forget Password
        public string? OtpSecret { get; set; }
        public DateTime? OtpExpiration { get; set; }
        public int OtpAttemptCount { get; set; }

        // Navigation Properties (one to many)
        public List<UserTopic> UserTopics { get; set; } = new List<UserTopic>();
    }
}
