using api.Core.Entities;
using api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Infrastructure.Services
{
    public static class SeedDataExtension
    {
        public static async Task SeedFeedSourcesAsync(this AppDbContext context)
        {
            if(!await context.FeedSource.AnyAsync())
            {
                var feedSources = new List<FeedSource>
                {
                    new FeedSource
                    {
                        Name = "BBC News",
                        Url = "https://feeds.bbci.co.uk/news/rss.xml",
                        Type = "RSS",
                        Description = "BBC News RSS Feed",
                        Language = "en",
                        Category = "NEWS",
                        IsActive = true,
                    },
                    new FeedSource
                    {
                        Name = "TechCrunch",
                        Url = "https://feeds.feedburner.com/TechCrunch/",
                        Type = "RSS",
                        Description = "TechCrunch RSS Feed",
                        Language = "en",
                        Category = "TECHNOLOGY",
                        IsActive = true,
                    }
                };

                await context.FeedSource.AddRangeAsync(feedSources);
                await context.SaveChangesAsync();
            }
        }
    }
}
