using api.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Commands.FeedSourceCommands
{
    public class CreateFeedSourceCommand : IRequest<FeedSourceResponse>
    {
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? ImageUrl { get; set; } = string.Empty;
        public string? Language { get; set; } = string.Empty;
        public string? Category { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
