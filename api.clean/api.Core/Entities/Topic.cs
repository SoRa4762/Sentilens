using api.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Core.Entities
{
    public class Topic : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Navigation Properties (one to many)
        public List<UserTopic> UserTopics { get; set; } = new();
        public List<FeedSourceTopic> FeedSourceTopics { get; set; } = new();
    }
}
