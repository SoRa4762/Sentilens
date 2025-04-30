using api.Core.Entities;
using api.Core.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Core.Interfaces
{
    public interface IArticleRepository : IRepository<Article>
    {
        Task<bool> ExistsByUrlAsync(string url);
        Task<IReadOnlyList<Article>> GetAllByFeedSourceIdAsync(int feedSourceId);
        Task<IReadOnlyList<Article>> GetAllByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IReadOnlyList<Article>> GetAllByFeedSourceIdAndDateRangeAsync(int feedSourceId, DateTime startDate, DateTime endDate);
        // Don't have userTopicId huh?
        // no 1 to 1 relationship, but many bridge entities in the middle, let's see how we can do it eh?
        //Task<IReadOnlyList<Article>> GetAllByUserTopicIdAsync(int userTopicId);
    }
}
