using api.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Core.Entities
{
    public class FeedSource : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? ImageUrl { get; set; } = string.Empty;
        public string? Language { get; set; } = string.Empty;
        public string? Category { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        // Navigation Properties (one to many)
        public List<Article>? Articles { get; set; } = new();
        // if it's optional no need to initialize it
        public List<FeedSourceTopic>? FeedSourceTopics { get; set; }

    }
}
