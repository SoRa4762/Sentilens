using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Infrastructure.Services
{
    public class FeedAggregatorService : BackgroundService
    {
        private readonly IServiceProvider _services;
        private readonly ILogger<FeedAggregatorService> _logger;

        public FeedAggregatorService(IServiceProvider service, ILogger<FeedAggregatorService> logger)
        {
            _services = service;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    // New scope PER ITERATION
                    using var scope = _services.CreateScope();

                    // Resolve fresh dependencies
                    var fetcher = scope.ServiceProvider.GetRequiredService<IFeedFetcher>();

                    // Use dependencies
                    await fetcher.FetchAllFeedsAsync();

                    // Scope is disposed here → services cleaned up
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred while fetching feeds");
                }
                await Task.Delay(TimeSpan.FromHours(1), cancellationToken);
            }
        }
    }
}
