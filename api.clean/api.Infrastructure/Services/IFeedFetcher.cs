using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Infrastructure.Services
{
    public interface IFeedFetcher
    {
        Task FetchAllFeedsAsync();
        //Task FetchFeedAsync(string feedUrl);
        //Task FetchFeedItemsAsync(string feedUrl);
        //Task FetchFeedItemAsync(string feedUrl, string itemId);
    }
}
