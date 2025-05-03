using api.Core.Entities;
using api.Core.Interfaces;
using api.Infrastructure.Data;
using api.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Infrastructure.Repositories
{
    public class FeedSourceRepository : Repository<FeedSource>, IFeedSourceRepository
    {
        public FeedSourceRepository(AppDbContext context) : base(context) { }
        // ** I don't have users rn, huh, need to think of a new logic huh?
        public async Task<IReadOnlyList<FeedSource>> GetAllByUserTopicIdAsync(int userTopicId)
        {
            return await _context.FeedSource
                .Where(fs => fs.Id == userTopicId)
                .ToListAsync();
        }

        // ** might have to change the CreatedAt field with the actual date field... but that is for later!
        public async Task<IReadOnlyList<FeedSource>> GetAllByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.FeedSource
                .Where(fs => fs.CreatedAt >= startDate &&
                             fs.CreatedAt <= endDate)
                .ToListAsync();
        }

        // ** make changes here as well, later
        public async Task<IReadOnlyList<FeedSource>> GetAllByUserTopicIdAndDateRangeAsync(int userTopicId, DateTime startDate, DateTime endDate)
        {
            return await _context.FeedSource
                .Where(fs => fs.Id == userTopicId &&
                             fs.CreatedAt >= startDate &&
                             fs.CreatedAt <= endDate)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<FeedSource>> GetAllFeedSourcesWithArticles()
        {
            return await _context.FeedSource
                .Select(fs => new FeedSource
                {
                    Name = fs.Name,
                    Url = fs.Url,
                    Description = fs.Description,
                    Language = fs.Language,
                    Category = fs.Category,
                    IsActive = fs.IsActive,
                    Articles = fs.Articles
                    .OrderByDescending(a => a.PublishedAt)
                    .Take(7)
                    .ToList()
                })
                .ToListAsync();

            // not the desired result!
            //return await _context.FeedSource
            //    .Include(fs => fs.Articles
            //    .OrderByDescending(a => a.CreatedAt)
            //    .Take(7))
            //    .ToListAsync();
        }

        public async Task<FeedSource> GetFeedSourceWithArticlesById(int FeedSourceId)
        {
            return await _context.FeedSource
                .Where(fs => fs.Id == FeedSourceId)
                .Select(fs => new FeedSource
                {
                    Name = fs.Name,
                    Url = fs.Url,
                    Description = fs.Description,
                    Language = fs.Language,
                    Category = fs.Category,
                    IsActive = fs.IsActive,
                    Articles = fs.Articles
                    .OrderByDescending(a => a.PublishedAt)
                    .Take(7)
                    .ToList()
                })
                .FirstOrDefaultAsync();
        }
    }
}
