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

        public async Task<Result<bool>> AddUserTopicAsync(string userId, int topicId)
        {
            var user = await _context.Users.FindAsync(userId);
            var topic = await _context.Topics.FindAsync(topicId);

            if(user == null || topic == null)
            {
                return Result<bool>.Failure("User or Topic not found");
            }

            // let's create a mapper later... for now let's just do as it is.
            var userTopic = new UserTopic
            {
                UserId = userId,
                TopicId = topicId
            };

            await _context.UserTopics.AddAsync(userTopic);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return Result<bool>.Success(true);
            }
            else
            {
                return Result<bool>.Failure("Failed to add UserTopic");
            }
        }

        public async Task<Result<bool>> DeleteUserTopic(string userId, int topicId)
        {
            var userTopic = await _context.UserTopics
                .FirstOrDefaultAsync(ut => ut.UserId == userId && ut.TopicId == topicId);

            if (userTopic == null)
                return Result<bool>.Failure("UserTopic not found");

            _context.UserTopics.Remove(userTopic);
            await _context.SaveChangesAsync();
            return Result<bool>.Success(true);
        }

        public async Task<IReadOnlyList<UserTopic>> GetUserTopicByIdAsync(string userId, int topicId)
        {
            //return await _context.UserTopics
            //    .Include(u => u.User)
            //    .ThenInclude(ut => ut.UserTopics)
            //    .ToListAsync();

            var userTopics = await _context.UserTopics
                .Include(ut => ut.Topic)
                .Where(ut => ut.UserId == userId && ut.TopicId == topicId)
                .ToListAsync();

            return userTopics;
        }

        //public Task<Result<bool>> UpdateUserTopicAsync(string userId, int topicId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
