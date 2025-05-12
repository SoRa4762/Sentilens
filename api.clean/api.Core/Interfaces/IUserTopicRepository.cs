using api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Core.Interfaces
{
    public interface IUserTopicRepository
    {
        Task<UserTopic> GetUserTopicByIdAsync(string userId, int topicId);
    }
}
