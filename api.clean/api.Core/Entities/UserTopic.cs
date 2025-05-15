using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Core.Entities
{
    public class UserTopic
    {
        public string UserId { get; set; }
        public int TopicId { get; set; }
        public DateTime SubscribedDate { get; set; } = DateTime.UtcNow;

        // Navigation Properties (one to one)
        public User User { get; set; }
        public Topic Topic { get; set; }
    }
}
