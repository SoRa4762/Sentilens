using api.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Core.Entities
{
    public class Article : Entity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public DateTime PublishedAt { get; set; }
        public string? ImageUrl { get; set; } = string.Empty;
        public float SentimentScore { get; set; }

        // foreign key
        public int FeedSourceId { get; protected set; }
        // navigation property (one to one)
        public FeedSource? FeedSource { get; set; }
    }
}
