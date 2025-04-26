using api.Application.Responses;
using api.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Commands.ArticleCommands
{
    public class CreateArticleCommand : IRequest<ArticleResponse>
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public DateTime PublishedAt { get; set; }
        public string? ImageUrl { get; set; } = string.Empty;
        public float SentimentScore { get; set; }
        // foreign key
        public int FeedSourceId { get; set; }
        //public FeedSource? FeedSource { get; set; }
        //public FeedSource FeedSource { get; set; }

    }
}