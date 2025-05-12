using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Responses
{
    public record UserTopicResponse
    {
        public string UserId { get; set; }
        public string TopicName { get; set; }
        public DateTime SubscribedDate { get; set; }
    }
}
