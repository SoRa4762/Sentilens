using api.Core.Entities;
using api.Core.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Core.Interfaces
{
    public interface IFeedSourceRepository : IRepository<FeedSource>
    {
        Task<IReadOnlyList<FeedSource>> GetAllByUserTopicIdAsync(int userTopicId);
        Task<IReadOnlyList<FeedSource>> GetAllByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IReadOnlyList<FeedSource>> GetAllByUserTopicIdAndDateRangeAsync(int userTopicId, DateTime startDate, DateTime endDate);
    }
}
