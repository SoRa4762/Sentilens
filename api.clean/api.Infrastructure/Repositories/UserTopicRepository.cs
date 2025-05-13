using api.Core.Entities;
using api.Core.Interfaces;
using api.Core.Utilities;
using api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Infrastructure.Repositories
{
    public class UserTopicRepository : IUserTopicRepository
    {
        private readonly AppDbContext _context;
        public UserTopicRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<UserTopic>> GetUserTopicByIdAsync(string userId, int toipcId)
        {
            return await _context.UserTopics
                .Include(u => u.User)
                .ThenInclude(ut => ut.UserTopics)
                .ToListAsync();
        }
    }
}
