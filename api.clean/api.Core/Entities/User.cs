using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace api.Core.Entities
{
    public class User : IdentityUser
    {
        /// <summary>
        // if it ain't public, it won't be serialized, won't be accessible to AppDbContext
        /// </summary>
        public List<UserTopic> UserTopics { get; set; } = new List<UserTopic>();
    }
}
