using api.Application.Responses;
using api.Core.Entities;
using api.Core.Interfaces;
using api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
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

        public async Task<UserTopic> GetUserTopicByIdAsync(string userId, int topicId)
        {
            return await _context.UserTopics
                .Include(ut => ut.Topic)
                .Where(ut => ut.UserId == userId)
                .Select(ut => new UserTopicResponse
                {
                    UserId = ut.UserId,
                    TopicName = ut.Topic.Name,
                    SubscribedDate = ut.SubscribedDate
                })
                .ToListAsync();
        }
    }
}
