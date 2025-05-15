using api.Core.Entities;
using api.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Core.Interfaces
{
    public interface IUserTopicRepository
    {
        Task<IReadOnlyList<UserTopic>> GetUserTopicsByUserIdAsync(string userId);
        Task<IReadOnlyList<UserTopic>> GetUsersByTopicIdAsync(int topicId);
        Task<IReadOnlyList<UserTopic>> GetUserTopicByIdsAsync(string userId, int topicId);
        Task<Result<bool>> AddUserTopicAsync(string userId, int topicId);
        Task<Result<bool>> DeleteUserTopic(string userId, int topicId);
        // do we even?
        //Task<Result<bool>> UpdateUserTopicAsync(string userId, int topicId);
    }
}
