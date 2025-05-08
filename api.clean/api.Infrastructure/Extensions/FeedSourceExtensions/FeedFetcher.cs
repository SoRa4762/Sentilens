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
using api.Infrastructure.Extensions.SentimentExtensions;

namespace api.Infrastructure.Extensions.FeedSourceExtensions
{
    public class FeedFetcher : IFeedFetcher
    {
        private readonly ILogger<FeedFetcher> _logger;
        private readonly IFeedSourceRepository _feedSourceRepository;
        private readonly IArticleRepository _articleRepository;
        private readonly HttpClient _httpClient;
        private readonly ISentimentAnalyzer _sentimentAnalyzer;

        public FeedFetcher(HttpClient httpClient, ILogger<FeedFetcher> logger, IFeedSourceRepository feedSourceRepository, IArticleRepository articleRepository, ISentimentAnalyzer sentimentAnalyzer)
        {
            _httpClient = httpClient;
            _logger = logger;
            _feedSourceRepository = feedSourceRepository;
            _articleRepository = articleRepository;
            _sentimentAnalyzer = sentimentAnalyzer;
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

                    // Sentiment Score
                    float sentimentScore = 0.5f; // Default/neutral score

                    // Map to Article entities - manually
                    var articles = feed.Items.Select(item =>
                    {
                        try
                        {
                            sentimentScore = _sentimentAnalyzer.AnalyzeSentiment(item.Summary.Text);
                        } catch (Exception ex)
                        {
                            _logger.LogError(ex, "Error Getting the Sentiment Score");
                        }

                        return new Article
                        {
                            Title = item.Title.Text,
                            //Description = item.Content?,
                            Content = item.Summary.Text,
                            Url = item.Links.FirstOrDefault()?.Uri.ToString(),
                            PublishedAt = item.PublishDate.UtcDateTime,
                            SentimentScore = sentimentScore,
                            FeedSourceId = feedSource.Id,
                        };
                    });
                    await SaveArticleAsync(articles.ToList());
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
