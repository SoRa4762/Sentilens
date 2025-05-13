using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Responses
{
    public record UserTopicResponse
    {
        public string UserId { get; set; } = string.Empty;
        public int TopicId { get; set; }
        public string TopicName { get; set; } = string.Empty;
        public DateTime SubscribedDate { get; set; }
    }
}
