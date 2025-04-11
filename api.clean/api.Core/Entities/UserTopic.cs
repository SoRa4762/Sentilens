using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Core.Entities
{
    public class UserTopic
    {
        public string UserId { get; set; } = string.Empty;
        public int TopicId { get; set; }
    }
}
