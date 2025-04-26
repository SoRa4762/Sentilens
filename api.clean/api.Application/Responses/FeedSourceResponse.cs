using api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Responses
{
    public class FeedSourceResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? ImageUrl { get; set; } = string.Empty;
        public string? Language { get; set; } = string.Empty;
        public string? Category { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public List<Article>? Articles { get; set; }
    }
}
