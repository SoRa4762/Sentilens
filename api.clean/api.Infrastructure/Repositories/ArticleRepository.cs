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
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        // passing context to the base class aka Repository<T> so that it can access AppDbContext
        //public ArticleRepository(AppDbContext context)
        //{
        //    _context = context;
        //}

        public ArticleRepository(AppDbContext context) : base(context) { }

        public async Task<IReadOnlyList<Article>> GetAllByFeedSourceIdAsync(int feedSourceId)
        {
            return await _context.Article
                .Where(a => a.FeedSourceId == feedSourceId)
                .ToListAsync();
        }
    }
}
