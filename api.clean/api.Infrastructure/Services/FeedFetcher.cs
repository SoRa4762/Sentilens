using api.Core.Entities;
using api.Core.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.ServiceModel.Syndication;

namespace api.Infrastructure.Services
{
    public class FeedFetcher : IFeedFetcher
    {
        private readonly ILogger<FeedFetcher> _logger;
        private readonly IFeedSourceRepository _feedSourceRepository;
        private readonly IArticleRepository _articleRepository;
        private readonly HttpClient _httpClient;

        public FeedFetcher(HttpClient httpClient, ILogger<FeedFetcher> logger, IFeedSourceRepository feedSourceRepository, IArticleRepository articleRepository)
        {
            _httpClient = httpClient;
            _logger = logger;
            _feedSourceRepository = feedSourceRepository;
            _articleRepository = articleRepository;
        }

        public async Task FetchAllFeedsAsync()
        {
            var feedSources = await _feedSourceRepository.GetAllAsync();
            foreach (var feedSource in feedSources)
            {
                try
                {
                    // Fetch RSS feed content
                    var response = await _httpClient.GetAsync(feedSource.Url);
                    response.EnsureSuccessStatusCode();
                    var stream = await response.Content.ReadAsStreamAsync();

                    // Parse the RSS feed using SyndicationFeed
                    using var reader = XmlReader.Create(stream);
                    var feed = SyndicationFeed.Load(reader);

                    // Map to Article entities - manually
                    var articles = feed.Items.Select(item => new Article
                    {
                        Title = item.Title.Text,
                        Content = item.Summary.Text,
                        Url = item.Links.FirstOrDefault()?.Uri.ToString(),
                        PublishedAt = item.PublishDate.UtcDateTime,
                        FeedSourceId = feedSource.Id,
                    }).ToList();
                    await SaveArticleAsync(articles);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error fetching feed {FeedSource}", feedSource.Url);
                }
            }
        }

        private async Task SaveArticleAsync(List<Article> articles)
        {
            foreach (var article in articles)
            {
                if(!await _articleRepository.ExistsByUrlAsync(article.Url))
                {
                    await _articleRepository.AddAsync(article);
                }
            }
        }
    }
}
